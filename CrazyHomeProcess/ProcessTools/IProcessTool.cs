using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyDebug.ProcessTools
{         
    internal class ExampleTool : IProcessTool
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        //private bool _enabled = false;

        public bool Start()        
        {
            _logger.Info("Somewhat IProcessTool Starting...");
            Enabled = true;
            return true;
        }

        public bool Stop()
        {
            _logger.Info("Somewhat IProcessTool Stopping...");
            Enabled = false;
            return true;
        }

        public bool Enabled { get; set; } // set; shitting here 
    }    

    interface IProcessTool
    {
        bool Start();
        bool Stop();
        bool Enabled { get; set; }
    }
}
