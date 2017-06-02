using System;
using U;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web.UZeroLogging.LogApps
{
    public partial class Add : AuthPageBase
    {
        IGuidGenerator guidGenerator = UPrimeEngine.Instance.Resolve<IGuidGenerator>();
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            if (!IsPostBack) {
                tbKey.Text = guidGenerator.Create().ToString().Replace("-", "");
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            
            #region 添加
            string name = tbName.Text.Trim();
            string desc = tbDescription.Text.Trim();
            string key = tbKey.Text.Trim();

            _appService.Create(name, desc, key, ddlIsTests.SelectedValue == "1");

            ltlMessage.Text = AlertSuccess("添加成功");
            RedirectByTime(GetBackUrlDecoded("List.aspx"), 1000);
            #endregion
        }
    }
}