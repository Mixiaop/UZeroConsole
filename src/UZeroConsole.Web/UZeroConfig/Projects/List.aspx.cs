using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U;
using UZeroConsole.Services.Config;

namespace UZeroConsole.Web.UZeroConfig.Projects
{
    public partial class List : AuthPageBase
    {
        IConfigService _configService = UPrimeEngine.Instance.Resolve<IConfigService>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}