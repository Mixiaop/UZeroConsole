using System;
using AjaxPro;
using U;
using U.Application.Services.Dto;
using UZeroConsole.Services.Installation;

namespace UZeroConsole.Web.UZero.Install
{
    [AjaxNamespace("InstallIndexPageService")]
    public partial class Index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.UZero.Install.Index));

            var installService = UPrimeEngine.Instance.Resolve<IInstallationService>();
            if (installService.IsInstalled())
            {
                Response.Redirect("/Default.aspx");
                Response.End();
            }
        }

        [AjaxMethod]
        public StateOutput Install(InstallInput input)
        {
            var installService = UPrimeEngine.Instance.Resolve<IInstallationService>();
            var connectionStr = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                                               input.DbHost,
                                               input.DbName,
                                               input.DbLoginName,
                                               input.DbLoginPassword);
            var res = installService.Install(connectionStr, input.AdminPassword);
            return res;
        }
    }

    public class InstallInput
    {
        public string DbHost { get; set; }

        public string DbName { get; set; }

        public string DbLoginName { get; set; }

        public string DbLoginPassword { get; set; }

        public string AdminPassword { get; set; }
    }

}