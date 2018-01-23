using U.Settings;

namespace UZeroConsole.Client
{
    [USettingsPathArribute("ClientSettings.json", "/Config/UZeroConsole/")]
    public class ClientSettings : USettings<ClientSettings>
    {
        public string JobsSoaHost { get; set; }
    }
}
