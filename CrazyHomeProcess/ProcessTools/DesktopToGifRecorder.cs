using NLog;
using CrazyDebug.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyDebug.ProcessToolsEngines;

namespace CrazyDebug.ProcessTools
{
    class DesktopToGifRecorder : IProcessTool
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private bool _enabled = false;        

        public bool Start()
        {
            _logger.Info("Start() starting");

            ScreenRecorder.StartRecording();
            _enabled = true;

            _logger.Info("Start() started");

            return true;
        }

        public bool Stop()
        {
            _logger.Info("Stop() stopping");

            _logger.Info("Stop() StopRecording()");
            ScreenRecorder.StopRecording();

            _logger.Info("Stop() recording stopped > saving");
            string outFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\video-" + DateTime.Now.ToLongTimeString().Replace(":", "-") + ".gif";
            ScreenRecorder.Save(outFilename);
            _logger.Info("Stop() recording saved");

            _logger.Info("Stop() ClearRecording()");
            ScreenRecorder.ClearRecording();
            _logger.Info("Stop() recording cleared");

            _enabled = false;

            _logger.Info("Stop() stopped");

            return true;
        }

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (value != _enabled)
                {
                    if (value)
                    {
                        Start();
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
        }
    }
}
