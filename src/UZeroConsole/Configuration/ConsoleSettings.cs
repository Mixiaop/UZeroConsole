using U.Settings;

namespace UZeroConsole.Configuration
{
    [USettingsPathArribute("ConsoleSettings.json", "/Config/UZeroConsole")]
    public class ConsoleSettings : USettings<ConsoleSettings>
    {
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
    }
}
