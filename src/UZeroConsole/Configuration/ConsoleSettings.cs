using U.Settings;

namespace UZeroConsole.Configuration
{
    [USettingsPathArribute("ConsoleSettings.json", "/Config/UZeroConsole")]
    public class ConsoleSettings : USettings<ConsoleSettings>
    {
        public bool IsDebug { get; set; }

        /// <summary>
        /// 应用名称（一般使用COOKIE或SESSION时当前缀使用）
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 控制台标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否使用Jobs应用（目前为 Hangfire 支持）
        /// </summary>
        public bool UseJobs { get; set; }

        /// <summary>
        /// 是否开启Sso
        /// </summary>
        public bool IsSsoOpend { get; set; }

        /// <summary>
        /// 是否为Sso服务端（false = 客户端）
        /// </summary>
        public bool IsSsoServer { get; set; }

        /// <summary>
        /// 默认一天，1440
        /// </summary>
        public int SsoAuthExpiresMinutes { get; set; }

        /// <summary>
        /// Sso服务端地址（客户端必填项）
        /// </summary>
        public string SsoServerHost { get; set; }

        /// <summary>
        /// 当前的Sso应用key
        /// </summary>
        public string SsoAppKey { get; set; }
    }
}
