using System;
using System.IO;
using U.Logging;
using UZeroConsole.Monitoring.Hosts;

namespace UZeroConsole.Web.UZeroSOA.Monitoring
{
    /// <summary>
    /// 接收客户端主机POST过来的性能信息
    /// </summary>
    public partial class Server : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var reqData = "";
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                reqData = sr.ReadLine();
            }

            if (reqData.IsNotNullOrEmpty())
            {
                try
                {
                    HostModule.Receive(reqData);
                    Response.Write("SUS");
                    Response.End();
                }
                catch (Exception ex)
                {
                    LogHelper.Logger.Error("出错了：" + ex.Message);
                }
            }
        }
    }
}