using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U;
using UZeroConsole.Services;

namespace UZeroConsole.Web._Tests
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IRoleService roleService = UPrimeEngine.Instance.Resolve<IRoleService>();

            var permissions = roleService.GetPermissions(2);
            var a = 1;

        }
    }
}