using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U;
using U.BackgroundJobs;
using U.Logging;

namespace UZeroConsole.Web._Tests
{
    public partial class JobTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //UPrimeEngine.Instance.Resolve<IBackgroundJobManager>().Enqueue<UZeroJobs.Jobs.UZeroRemoteJob, int>(2);
            //Response.Write("sucess");
            Response.Write(("2017-12-06 00:00:00").ToDateTime() < DateTime.Now);
        }
    }

    public class HelloWorldJob : BackgroundJob<int>, U.Dependency.ITransientDependency {

        public override void Execute(int args)
        {
            LogHelper.Logger.Debug("hello world：" + args);

        }
    }
}