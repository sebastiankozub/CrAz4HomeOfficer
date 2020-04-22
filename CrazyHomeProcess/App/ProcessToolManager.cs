using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyDebug.App
{
    public class ProcessToolManager<IServiceTool> : IToolManager<IServiceTool>
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private Dictionary<string, IServiceTool> InstalledTools = new Dictionary<string, IServiceTool>();

        public IServiceTool GetByName(string name)
        {
            return InstalledTools[name];
        }

        public bool Install(string name, IServiceTool tool)
        {
            try
            {
                InstalledTools.Add(name, tool);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    interface IToolManager<T> 
    {
        T GetByName(string name);
        bool Install(string name, T tool);
    }
}
