using System;
using U;
using U.Settings;
using UZeroConsole.Configuration;

namespace UZeroConsole.Web.UZero.Configuration
{
    public partial class SetCorpWeixinSettings : AuthPageBase
    {
        ConsoleSettings _settings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
        CorpWeixinSettings _weixinSettings = UPrimeEngine.Instance.Resolve<CorpWeixinSettings>();
        ISettingsManager _settingsManager = UPrimeEngine.Instance.Resolve<ISettingsManager>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            if (!IsPostBack)
            {
                ddlIsOpend.SelectedValue = _settings.IsCorpWeixinLoginOpened ? "1" : "0";
                tbCorpId.Text = _weixinSettings.CorpId;
                tbAuthAgentId.Text = _weixinSettings.AuthAgentId;
                tbAuthSecret.Text = _weixinSettings.AuthSecret;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _settings.IsCorpWeixinLoginOpened = ddlIsOpend.SelectedValue == "1" ? true : false;
            _weixinSettings.CorpId = tbCorpId.Text.Trim();
            _weixinSettings.AuthAgentId = tbAuthAgentId.Text.Trim();
            _weixinSettings.AuthSecret = tbAuthSecret.Text.Trim();

            _settingsManager.SaveSettings(_settings);
            _settingsManager.SaveSettings(_weixinSettings);

            ltlMessage.Text = AlertSuccess("保存成功", "", 5000);
        }
    }
}