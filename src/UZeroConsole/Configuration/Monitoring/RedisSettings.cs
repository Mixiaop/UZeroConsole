using System.Collections.Generic;
using U.Settings;

namespace UZeroConsole.Configuration.Monitoring
{
    [USettingsPathArribute("RedisSettings.json", "/Config/UZeroConsole/Monitoring/")]
    public class RedisSettings : USettings<RedisSettings>
    {
        public List<Server> Servers { get; set; } = new List<Server>();

        public Server AllServers { get; set; } = new Server();

        public Server Defaults { get; set; } = new Server();

        public class Server 
        {
            public List<Instance> Instances { get; set; } = new List<Instance>();

            /// <summary>
            /// 控制台显示的名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 轮询的间隔（秒）
            /// </summary>
            public int RefreshIntervalSeconds { get; set; } = 30;
        }
        public class Instance 
        {
            /// <summary>
            /// 节点的名称（IP）
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 节点的连接端口
            /// </summary>
            public int Port { get; set; } = 6379;

            /// <summary>
            /// 密码
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// 是否使用SSL
            /// </summary>
            public bool UseSSL { get; set; } = false;

            /// <summary>
            /// 用于分析的正则（用于对键进行分析）
            /// </summary>
            public Dictionary<string, string> AnalysisRegexes { get; set; } = new Dictionary<string, string>();
        }
    }
}
