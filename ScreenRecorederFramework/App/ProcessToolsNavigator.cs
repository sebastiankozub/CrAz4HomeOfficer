using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using CrazyDebug.ProcessTools;

namespace CrazyDebug.App
{
    class ProcessToolsNavigator
    {
        public static void Configure(IToolManager<IProcessTool> tools, IKeyboardMouseEvents events, Action exitAction)
        {
            var keyCombinationToActionMap = new Dictionary<Combination, Action>
            {
                { Combination.FromString("Control+K+L"), () => { tools.GetByName("desktopKeyHook").Start(); } },
                { Combination.FromString("Control+K+J"), () => { tools.GetByName("desktopKeyHook").Stop(); } },

                { Combination.FromString("Control+S+D"), () => { tools.GetByName("desktopRecorder").Start(); } },
                { Combination.FromString("Control+S+A"), () => { tools.GetByName("desktopRecorder").Stop(); } },
            };

            events.KeyPress += (o, e) => { if (e.KeyChar == 'q') exitAction(); };
            events.OnCombination(keyCombinationToActionMap);
        }

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
