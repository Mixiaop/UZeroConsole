using System.Collections.Generic;
using U.Settings;

namespace UZeroConsole.Configuration.Monitoring
{
    [USettingsPathArribute("SQLSettings.json", "/Config/UZeroConsole/Monitoring/")]
    public class SQLSettings : USettings<SQLSettings>
    {
        /// <summary>
        /// 默认连接字符串
        /// </summary>
        public string DefaultConnectionString { get; set; }

        /// <summary>
        /// 默认刷新间隔（对所有服务器轮询的频率）
        /// </summary>
        public int RefreshIntervalSeconds { get; set; }

        public IList<Cluster> Clusters { get; set; } = new List<Cluster>();

        public IList<Instance> Instances { get; set; } = new List<Instance>();

        /// <summary>
        /// Sql always on 集群配置
        /// </summary>
        public class Cluster
        {
            /// <summary>
            /// 别名
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 简介
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 刷新间隔（null则使用默认的）
            /// </summary>
            public int? RefreshIntervalSeconds { get; set; }

            /// <summary>
            /// always on 节点列表
            /// </summary>
            public List<Instance> Nodes { get; set; } = new List<Instance>();
        }
        /// <summary>
        /// Sql实例配置
        /// </summary>
        public class Instance
        {
            /// <summary>
            /// 别名（机器名）
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 简介
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 连接字符串
            /// </summary>
            public string ConnectionString { get; set; }

            /// <summary>
            /// 对象名
            /// </summary>
            public string ObjectName { get; set; }

            /// <summary>
            /// 刷新间隔（null则使用默认的）
            /// </summary>
            public int? RefreshIntervalSeconds { get; set; }
        }
    }
}
