using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web.UZeroLogging.LogApps
{
    public partial class Edit : AuthPageBase
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();

        protected EditModel Model = new EditModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            Model.LogApp = _appService.Get(Model.GetAppId);
            if (Model.LogApp == null)
                Response.Redirect("List.aspx");

            if (!IsPostBack)
            {
                tbName.Text = Model.LogApp.Name;
                tbDescription.Text = Model.LogApp.Description;
                tbKey.Text = Model.LogApp.Key;
                ddlIsTests.SelectedValue = Model.LogApp.IsTests ? "1" : "0";
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {

            #region 保存
            Model.LogApp.Name = tbName.Text.Trim();
            Model.LogApp.Description = tbDescription.Text.Trim();
            Model.LogApp.IsTests = ddlIsTests.SelectedValue == "1";

            _appService.Update(Model.LogApp);

            ltlMessage.Text = AlertSuccess("保存成功");
            RedirectByTime(GetBackUrlDecoded("List.aspx"), 1000);
            #endregion
        }
    }

    public class EditModel {
        public int GetAppId { get { return WebHelper.GetInt("appId", 0); } }

        public LogApp LogApp { get; set; }
    }
}