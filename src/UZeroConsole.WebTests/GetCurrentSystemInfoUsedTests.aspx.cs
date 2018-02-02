using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace UZeroConsole.WebTests
{
    public partial class GetCurrentSystemInfoUsedTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WriteLine("CPU", GetCpuPercent().ToString());
        }

        private void WriteLine(string name, string msg)
        {
            Response.Write(string.Format("{0}：{1} <br />", name, msg));
        }

        public double GetCpuPercent()
        {
            var cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var percentage = cpu.NextValue();
            return Math.Round(percentage, 2, MidpointRounding.AwayFromZero);
        }
    }
}