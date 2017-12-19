using System;
using U;
using U.Settings;
using UZeroConsole.Configuration;

namespace UZeroConsole.Web.UZero.Configuration
{
    /// <summary>
    /// 通用配置
    /// </summary>
    public partial class SetConsoleSettings : AuthPageBase
    {
        ConsoleSettings _settings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
        ISettingsManager _settingsManager = UPrimeEngine.Instance.Resolve<ISettingsManager>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            if (!IsPostBack) {
                ddlIsDebug.SelectedValue = _settings.IsDebug ? "1" : "0";
                tbTitle.Text = _settings.Title;
                ddlUseJobs.SelectedValue = _settings.UseJobs ? "1" : "0";
                ddlIsSsoOpened.SelectedValue = _settings.IsSsoOpend ? "1" : "0";
                ddlIsSsoServer.SelectedValue = _settings.IsSsoServer ? "1" : "0";
                tbSsoAuthExpiresMinutes.Text = _settings.SsoAuthExpiresMinutes.ToString();
                tbSsoServerHost.Text = _settings.SsoServerHost;
                tbSsoAppKey.Text = _settings.SsoAppKey;
                ddlUNoteExternalLoginOpened.SelectedValue = _settings.UNoteExternalLoginOpened ? "1" : "0";
                tbUNoteExternalLoginUrl.Text = _settings.UNoteExternalLoginUrl;
                tbUNoteAppKey.Text = _settings.UNoteAppKey;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region Save
            _settings.IsDebug = ddlIsDebug.SelectedValue == "1" ? true : false;
            _settings.Title = tbTitle.Text.Trim();
            _settings.UseJobs = ddlUseJobs.SelectedValue == "1" ? true : false;
            _settings.IsSsoOpend = ddlIsSsoOpened.SelectedValue == "1" ? true : false;
            _settings.IsSsoServer = ddlIsSsoServer.SelectedValue == "1" ? true : false;
            _settings.SsoAuthExpiresMinutes = tbSsoAuthExpiresMinutes.Text.Trim().ToInt();
            _settings.SsoServerHost = tbSsoServerHost.Text.Trim();
            _settings.SsoAppKey = tbSsoAppKey.Text.Trim();
            _settings.UNoteExternalLoginOpened = ddlUNoteExternalLoginOpened.SelectedValue == "1" ? true : false;
            _settings.UNoteExternalLoginUrl = tbUNoteExternalLoginUrl.Text.Trim();
            _settings.UNoteAppKey = tbUNoteAppKey.Text.Trim();

            _settingsManager.SaveSettings(_settings);

            ltlMessage.Text = AlertSuccess("保存成功", "", 5000);

            #endregion
        }
    }
}