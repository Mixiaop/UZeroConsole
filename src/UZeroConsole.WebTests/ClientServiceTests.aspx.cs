using Newtonsoft.Json;
using System;
using U;
using UZeroConsole.Client;
namespace UZeroConsole.WebTests
{
    public partial class ClientServiceTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILoggingClientService clientService = UPrimeEngine.Instance.Resolve<ILoggingClientService>();
            //for (var i = 0; i < 20; i++) 
            //clientService.LogAsync("用户登录", Domain.Logging.ActionLogOperateType.None, "浙江", "", "2", "用户【14847296】登录了，来自【Android，省份版本（839：辽宁）】" + Guid.NewGuid(), "", "d27b1eb4e55744729be0e4ec5657531c", "http://localhost:8400/");

            var res = clientService.Search("", "1", 1, 10, "d27b1eb4e55744729be0e4ec5657531c", "http://localhost:8400/");
            Response.Write(JsonConvert.SerializeObject(res));
        }
    }
}