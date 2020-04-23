using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Imaging = System.Drawing.Imaging;
using NLog;

namespace CrazyDebug.ProcessToolsEngines
{
    public class ScreenRecorder
    {
        private static readonly Logger _Logger = LogManager.GetCurrentClassLogger();

        // C:\Users\sebas.000\AppData\Local\Temp\snapshot
        private static string tempSnapshotDir = Path.GetTempPath() + "snapshot\\";
        private static Thread snapThread; // = new Thread(Snapshot);
        private static bool flag = false;

        private static Rectangle _Bounds = Screen.PrimaryScreen.Bounds;

        public static Rectangle Bounds
        {
            get { return _Bounds; }
            set { _Bounds = value; }
        }

        private static void Snapshot()
        {
            try
            {
                ClearRecording();

                using (var memoryBitmap = new Bitmap(_Bounds.Width, _Bounds.Height, Imaging.PixelFormat.Format32bppArgb))
                using (var graphSurface = Graphics.FromImage(memoryBitmap))
                {
                    var currentBounds = new Rectangle();
                    var Counter = (UInt64)0;
                    var freshPoint = new System.Drawing.Point();

                    flag = true;
                    do
                    {
                        Thread.Sleep(50);
                        graphSurface.CopyFromScreen(_Bounds.Location, freshPoint, _Bounds.Size);

                        // add cursor - not working
                        currentBounds.Size = Cursor.Current.Size;
                        currentBounds.Location = System.Drawing.Point.Subtract(Cursor.Position, Bounds.Size);
                        Cursors.Default.Draw(graphSurface, currentBounds);

                        Counter++;

                        var fileName = FormatFileName(Counter.ToString(), 6, '0', ".png");
                        using (var FS = new FileStream(string.Concat(tempSnapshotDir, fileName), FileMode.Create, FileAccess.Write))
                        {
                            memoryBitmap.Save(FS, ImageFormat.Png);
                        }

                    } while (flag);
                }
            }
            catch(Exception e)
            {
                _Logger.Info("ScreenRecorder.Snapshot() Exception !!!  {0} {1} {2} {3}", e.Message, e.InnerException, e.StackTrace, e.Source);
                throw e;
            }
        }

        public static void ClearRecording()
        {
            var autoResetEvent = new AutoResetEvent(false);

            try
            {
                _Logger.Info("ScreenRecorder.ClearRecording() Refreshing Dirs...");
                if (Directory.Exists(tempSnapshotDir))
                    Directory.Delete(tempSnapshotDir, true);

                Directory.CreateDirectory(tempSnapshotDir);
            }
            catch (IOException exc)
            {
                _Logger.Info("ScreenRecorder.ClearRecording() Exception !!! {0}", exc.Message);

                var fileSystemWatcher =
                    new FileSystemWatcher(Path.GetDirectoryName(tempSnapshotDir))
                    {
                        EnableRaisingEvents = true
                    };

                fileSystemWatcher.Changed +=
                    (o, e) =>
                    {
                        if (Path.GetFullPath(e.FullPath) == Path.GetFullPath(tempSnapshotDir))
                        {
                            autoResetEvent.Set();
                        }
                    };

                autoResetEvent.WaitOne();
            }
            catch (Exception e)
            {
                _Logger.Info("ScreenRecorder.ClearRecording() Exception !!!  {0} {1} {2} {3}", e.Message, e.InnerException, e.StackTrace, e.Source);
                throw;
            }
        }

        public static void StartRecording()
        {
            snapThread = new Thread(Snapshot);
            snapThread.Start();
        }

        public static void StopRecording()
        {
            try
            {
                flag = false;
                snapThread.Join();
            }
            catch (Exception e)
            {
                _Logger.Info("ScreenRecorder.StopRecording() Exception !!!  {0} {1} {2} {3}", e.Message, e.InnerException, e.StackTrace, e.Source);
                throw;
            }
        }

        public static void Save(string outpuFilename)
        {
            try
            {
                _Logger.Info("ScreenRecorder.Save()");
                var gifBitmapEncoder = new GifBitmapEncoder();
                var fileStreamList = new List<FileStream>();

                try
                {
                    _Logger.Info("ScreenRecorder.Save() encode PNG to GIF");
                    foreach (string pngFile in Directory.GetFiles(tempSnapshotDir, "*.png", SearchOption.TopDirectoryOnly)) // efficiency !!! create list like Counter !!!
                    {
                        var tempStream = new FileStream(pngFile, FileMode.Open);
                        var bitmapFrame = BitmapFrame.Create(tempStream);                        

                        fileStreamList.Add(tempStream);
                        gifBitmapEncoder.Frames.Add(bitmapFrame);
                        //tempStream.
                    }

                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();

                    GC.Collect(2);

                    _Logger.Info("ScreenRecorder.Save() save GIF");
                    using (var fileStream = new FileStream(outpuFilename, FileMode.Create, FileAccess.Write))
                    {
                        gifBitmapEncoder.Save(fileStream);
                    }
                    _Logger.Info("ScreenRecorder.Save() GIF Seved!");
                }
                catch (Exception e)
                {
                    _Logger.Info("ScreenRecorder.Save() Exception !!!  {0} {1} {2} {3}", e.Message, e.InnerException, e.StackTrace, e.Source);
                    throw;
                }
                finally
                {
                    _Logger.Info("ScreenRecorder.Save() gifBitmapEncoder.Clear()");
                    gifBitmapEncoder.Frames.Clear();

                    _Logger.Info("ScreenRecorder.Save() fileStreamList.Clear()");
                    fileStreamList.ForEach(x => x.Dispose());
                    fileStreamList.Clear();
                }

                _Logger.Info("ScreenRecorder.Save() returning");
            }
            catch(Exception e)
            {
                _Logger.Info("ScreenRecorder.Save() Exception !!! {0} {1} {2} {3}", e.Message, e.InnerException, e.StackTrace, e.Source);
                throw;
            }
        }

        private static string FormatFileName(string S, int places, char character, string extension)
        {
            if (S.Length >= places)
                return S;

            return S.PadLeft(places, '0') + extension;
        }
    }
}
