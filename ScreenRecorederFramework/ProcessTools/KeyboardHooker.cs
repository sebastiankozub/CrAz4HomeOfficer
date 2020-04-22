using Gma.System.MouseKeyHook;
using NLog;
using CrazyDebug.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyDebug.ProcessTools
{
    class KeyboardHooker : IProcessTool
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private bool _enabled = false;
        private IKeyboardMouseEvents _events;

        public bool Start()
        {
            _logger.Info("Start() starting KeyboardHooker");

            _events = Hook.GlobalEvents();
            _events.KeyPress += GlobalHookKeyPress;
            _enabled = true;

            _logger.Info("Start() KeyboardHooker started");

            return true;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            _logger.Info("KeyboardHooker : {0}", e.KeyChar);
        }   

        public bool Stop()
        {
            _logger.Info("Stop() stopping KeyboardHooker");

            _events.KeyPress -= GlobalHookKeyPress;
            _events.Dispose();
            _enabled = false;

            _logger.Info("Stop() KeyboardHooker stopped");

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
