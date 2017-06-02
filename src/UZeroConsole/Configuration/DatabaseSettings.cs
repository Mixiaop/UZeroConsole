using U.Settings;

namespace UZeroConsole.Configuration
{
    [USettingsPathArribute("DatabaseSettings.json", "/Config/UZeroConsole")]
    public class DatabaseSettings : USettings<DatabaseSettings>
    {
        public string SqlConnectionString { get; set; }
        public string ReadonlySqlConnectionString { get; set; }
    }
}
