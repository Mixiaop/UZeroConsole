using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using U;
using UZeroConsole.Services.Installation;
namespace UZeroConsole.Web._Tests
{
    public partial class InstallTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var service = UPrimeEngine.Instance.Resolve<IInstallationService>();
            var res = service.Install("Data Source=120.132.57.7,1444;Initial Catalog=UZeroConsole.InstallTests;Persist Security Info=True;User ID=sa;Password=youzy.cn", "");
            if (res.Success)
            {
                Response.Redirect("/Default.aspx");
            }
            else
                Response.Write(JsonConvert.SerializeObject(res));
        }
    }
}