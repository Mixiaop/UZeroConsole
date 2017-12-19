using U.Settings;

namespace UZeroConsole.Configuration
{
    [USettingsPathArribute("DatabaseSettings.json", "/Config/UZeroConsole")]
    public class DatabaseSettings : USettings<DatabaseSettings>
    {
        /// <summary>
        /// 是否已安装
        /// </summary>
        public bool Installed { get; set; }

        public string SqlConnectionString { get; set; }
        public string ReadonlySqlConnectionString { get; set; }
    }
}
