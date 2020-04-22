using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.InteropServices;
using ScreenRecorederFramework;
using murrayju;
using murrayju.ProcessExtensions;
using NLog;

namespace HomeOfficerService
{
    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public int dwServiceType;
        public ServiceState dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    };


    public partial class HomeOfficerService : ServiceBase
    {
        private static readonly Logger _Logger = LogManager.GetCurrentClassLogger();

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        private int timerEventId = 1;
        private Timer timer;

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            this.OnStop();
        }

        public HomeOfficerService(string[] args)
        {
            InitializeComponent();

            string eventSourceName = "MySource";
            string logName = "MyNewLog";

            if (args.Length > 0)
            {
                eventSourceName = args[0];
            }
            if (args.Length > 1)
            {
                logName = args[1];
            }

            eventLogger = new EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("HomeOfficerServiceLoggerSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "HomeOfficerServiceLoggerSource", "HomeOfficerServiceLoggerNewLog");
            }
            eventLogger.Source = "HomeOfficerServiceLoggerSource";
            eventLogger.Log = "HomeOfficerServiceLoggerNewLog";
        }

        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // Run Timer to show some heeat-beat
            eventLogger.WriteEntry("In OnStart...");
            eventLogger.WriteEntry("V2.0", EventLogEntryType.Information);
            timer = new Timer
            {
                Interval = 6000 // 36 seconds
            };
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();

            // Update ServiceStatus to Running
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            StartProcessRunner();
        }

        public void StartProcessRunner()
        {
            _Logger.Info("HomeOfficerService : In RunProcessRunner...");
            eventLogger.WriteEntry("In RunProcessRunner...");

            try
            {
                //ScreenRecorederFramework.Program.Main(null);
                ProcessExtensions.StartProcessAsCurrentUser(@"D:\source\repos\ConsoleScreenRecorder\HomeOfficerService\bin\Debug\ScreenRecorederFramework.exe");
                //ProcessExtensions.StartProcessAsCurrentUser("calc.exe");
            }
            catch (Exception e)
            {
                eventLogger.WriteEntry(e.Message);
                eventLogger.WriteEntry(e.Source);
                eventLogger.WriteEntry(e.StackTrace);
                eventLogger.WriteEntry(e.TargetSite.Name);
                _Logger.Info("OnStart : " + e.Message);
                _Logger.Info("OnStart : " + e.Source);
                _Logger.Info("OnStart : " + e.StackTrace);
                _Logger.Info("OnStart : " + e.HelpLink);
                _Logger.Info("OnStart : " + e.TargetSite.Name);
                if (e.InnerException != null)
                {
                    var e1 = e.InnerException;
                    _Logger.Info("OnStart : " + e1.Message);
                    _Logger.Info("OnStart : " + e1.Source);
                    _Logger.Info("OnStart : " + e1.StackTrace);
                    _Logger.Info("OnStart : " + e1.HelpLink);
                    _Logger.Info("OnStart : " + e1.TargetSite.Name);
                }
            }
        }

        protected override void OnStop()
        {
            // Update the service state to Stop Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);


            timer.Dispose();


            // Update the service state to Stopped.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        private void EventLoggerEntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            _Logger.Info("HomeOfficerService : Monitoring the System {0} ", timerEventId++);
            eventLogger.WriteEntry("Monitoring the System", EventLogEntryType.Information, timerEventId++);
        }


    }
}
