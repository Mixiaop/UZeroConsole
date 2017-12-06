using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;
using U;
using U.Utilities.Net;
using U.Utilities.Web;
using UZeroConsole.Services.External;

namespace UZeroConsole.Web.External.EnterpriseWeixin
{
    public partial class CallbackTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var weixinService = UPrimeEngine.Instance.Resolve<ICorpWeixinService>();
            var code = WebHelper.GetString("code");
            Response.Write(WebHelper.GetString("adminId") + "<br />");
            if (code.IsNotNullOrEmpty())
            {
                var accessToken = weixinService.GetAccessToken();
                if (accessToken.IsSuccess()) {
                    var user = weixinService.GetUserId(accessToken.access_token, code);

                    if (user.IsSuccess()) {
                        Response.Write(JsonConvert.SerializeObject(user));
                    }
                }
                       
            }

        }


    }
    public class GetAccessTokenOutput {
        public int errcode { get; set; }

        public string errmsg { get; set; }

        public string access_token { get; set; }

        public int expires_in { get; set; }
    }
}