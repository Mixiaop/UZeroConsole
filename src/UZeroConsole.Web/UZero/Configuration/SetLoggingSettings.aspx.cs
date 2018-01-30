using System;
using U;
using U.Settings;
using UZeroConsole.Configuration;

namespace UZeroConsole.Web.UZero.Configuration
{
    public partial class SetLoggingSettings : AuthPageBase
    {
        //LoggingSettings _settings = UPrimeEngine.Instance.Resolve<LoggingSettings>();
        ISettingsManager _settingsManager = UPrimeEngine.Instance.Resolve<ISettingsManager>();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            if (!IsPostBack) {
                //_settings.SOAHost = tbSOAHost.Text.Trim();
                //_settings.DefaultKey = tbDefaultKey.Text.Trim();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //_settings.SOAHost = tbSOAHost.Text.Trim();
            //_settings.DefaultKey = tbDefaultKey.Text.Trim();

            //_settingsManager.SaveSettings(_settings);

            ltlMessage.Text = AlertSuccess("保存成功", "", 5000);
        }
    }
}