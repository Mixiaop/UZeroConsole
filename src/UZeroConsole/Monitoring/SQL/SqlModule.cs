using System;
using System.Collections.Generic;
using System.Linq;

namespace UZeroConsole.Monitoring.SQL
{
    public class SQLModule : StatusModule
    {
        /// <summary>
        /// 当前是否启动（有实例的情况下当前为启动状态）
        /// </summary>
        public static bool Enabled => AllInstances.Count > 0;

        /// <summary>
        /// 不包含集群的实例
        /// </summary>
        public static List<SQLInstance> StandaloneInstances { get; }

        /// <summary>
        /// 包含集群的所有实例
        /// </summary>
        public static List<SQLInstance> AllInstances { get; }

        static SQLModule()
        {
            StandaloneInstances = Current.MonitoringSettings.SQL.Instances
                                                                .Select(x => new SQLInstance(x))
                                                                .Where(x => x.TryAddToGlobalPollers())
                                                                .ToList();
            AllInstances = StandaloneInstances.ToList();

        }

        public static SQLInstance Get(string name)
        {
            var node = AllInstances.Find(i => string.Equals(i.Name, name, StringComparison.InvariantCultureIgnoreCase));
            if (node == null && AllInstances.Any())
            {
                return AllInstances[0];
            }
            else
                return node;
        }

        public override bool IsMember(string node)
        {
            return AllInstances.Any(i => string.Equals(i.Name, node, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
