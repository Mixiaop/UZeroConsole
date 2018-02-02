using System;
using System.ServiceProcess;
using System.IO;

namespace UZeroConsole.WinServices.PerformanceSender
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new PerformanceSenderService()
            };
            ServiceBase.Run(ServicesToRun);


        }
    }
}
