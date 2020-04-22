using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HomeOfficerService
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                HomeOfficerService homeOffivcerService = new HomeOfficerService(args);
                Console.WriteLine("HomeOfficerService in Environment.UserInteractive  created... ");
                homeOffivcerService.TestStartupAndStop(args);
            }
            else
            {
                //ServiceBase[] ServicesToRun;
                //ServicesToRun = new ServiceBase[] { new HomeOfficerService(args) };

                using (var homeOffivcerService = new HomeOfficerService(args))
                    ServiceBase.Run(homeOffivcerService);
            }
        }
    }
}
