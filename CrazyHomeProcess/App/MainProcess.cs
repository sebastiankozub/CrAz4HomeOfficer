using System;
using System.Windows.Forms;
using Timers = System.Timers;
using NLog;
using Gma.System.MouseKeyHook;
using System.Collections.Generic;
using CrazyDebug.ProcessTools;

namespace CrazyDebug.App
{
    public class MainProcess
    {
        private static readonly Logger _Logger = LogManager.GetCurrentClassLogger();

        private static Action exitAction;
        private static UInt64 seconds;
        private static IKeyboardMouseEvents globalEventHook;

        static MainProcess()
        {
            _Logger.Info("Static : Program()");
            seconds = 0;
            globalEventHook = Hook.GlobalEvents();
            exitAction = Application.Exit;
        }

        static void Main(string[] args)
        {
            _Logger.Info("Main() Entry Point");            
            // logger tests
            _Logger.Trace("Hello - Trace");
            _Logger.Debug("Hello - Debug");
            _Logger.Info("Hello - Info");
            _Logger.Warn("Hello - Warn");
            _Logger.Error("Hello - Error");
            _Logger.Fatal("Hello - Fatal");

            _Logger.Info("Config HeartbeatTimer");
            int m = 1; //seconds of logging
            _Logger.Info("Start and Config Seconds Timer");
            var heartbeatTimer = new Timers.Timer(m * 1000);
            heartbeatTimer.Elapsed += _heartbeatTimerTick;
            heartbeatTimer.AutoReset = true;
            heartbeatTimer.Start();

            var toolsManager = new ProcessToolManager<IProcessTool>();
            toolsManager.Install("desktopRecorder", new DesktopToGifRecorder());
            toolsManager.Install("desktopKeyHook", new KeyboardHooker());
            toolsManager.Install("desktopKeyHook", new KeyboardHooker()); 

            ProcessToolsNavigator.Configure(toolsManager, globalEventHook, exitAction);

            _Logger.Info("Running Message Loop with  Application.Run(new ApplicationContext())");
            Application.Run(new ApplicationContext());  // message loop for LowLevelKeyboardListener & MouseKeyHook

            globalEventHook.Dispose();

            _Logger.Info("Main() Exit");

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        static void _heartbeatTimerTick(object sender, EventArgs e)
        {
            _Logger.Info("heart-beat log {0}", (++seconds).ToString());
        }
    }
}


//public static void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
//{
//    _Logger.Info("KeyPressed {0}", e.KeyPressed.ToString());
//}

//public void Subscribe()
//{
//    _Logger.Info("MouseKeyHook : Subscribing");

//    // Note: for the application hook, use the Hook.AppEvents() instead
//    m_GlobalHook = Hook.GlobalEvents();
//    //m_GlobalHook
//    //Hook.AppEvents.
//    m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
//    m_GlobalHook.KeyPress += GlobalHookKeyPress;

//    _Logger.Info("MouseKeyHook : Subscribed");
//}

//private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
//{
//    _Logger.Info("MouseKeyHook : KeyPress: \t{0}", e.KeyChar);
//}

//private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
//{
//    _Logger.Info("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);
//    // uncommenting the following line will suppress the middle mouse button click
//    // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
//}

//public void Unsubscribe()
//{
//    _Logger.Info("MouseKeyHook : Unsubscribing");

//    m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
//    m_GlobalHook.KeyPress -= GlobalHookKeyPress;
//    //It is recommened to dispose it
//    m_GlobalHook.Dispose();

//    _Logger.Info("MouseKeyHook : Unsubscribed");
//}

//public static void _recorederTimerTick(object sender, EventArgs e)
//{
//    try
//    {
//        _Logger.Info("OnTimer_recorederTimerTick Application Exiting...");
//        exitAction();

//    }
//    catch(Exception exc)
//    {
//        throw exc;
//    }
//}
//_Logger.Info("LowLevelKeyboardListener : Unhooking keyboard...");
//_listener.UnHookKeyboard();

//private static IKeyboardMouseEvents m_GlobalHook;


//var dispacherTimer = new DispatcherTimer();            
//var recorderTimer = new Timers.Timer(n * 1000);
//recorderTimer.Elapsed += _recorederTimerTick;
//recorderTimer.AutoReset = false;

//_Logger.Info("Start Recording Timer");
//recorderTimer.Start();

//_Logger.Info("Config LowLevelKeyboardListener");
//_listener = new LowLevelKeyboardListener();
//_listener.OnKeyPressed += _listener_OnKeyPressed;
//_listener.HookKeyboard();
//_Logger.Info("Keyboard Hooked LowLevelKeyboardListener");

//appCtx = new ExitableApplicationContex();
//(new ScreenRecorederMainProcess()).Subscribe();
//_Logger.Info("Static : Program() : Subscribed to MouseKeyHook events...");

//static private LowLevelKeyboardListener _listener;
//public static ExitableApplicationContex appCtx;


//public class ExitableApplicationContex : ApplicationContext
//{
//    public void Exit()
//    {
//        ExitThread();
//    }
//}

//appCtx.Exit();
//Environment.Exit(0);
//Application.Exit();
//_Logger.Info("Env Exiting");
