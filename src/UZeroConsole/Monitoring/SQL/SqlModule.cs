using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZeroConsole.Monitoring.SQL
{
    public class SqlModule : StatusModule
    {
        public static bool Enabled => AllInstances.Count > 0;

        /// <summary>
        /// 不包含clusters
        /// </summary>
        public static List<SQLInstance> StandaloneInstances { get; }
        /// <summary>
        /// 包含clusters
        /// </summary>
        public static List<SQLInstance> AllInstances { get; }

        static SqlModule() {
            //StandaloneInstances = Current.Settings.SQL.Instances
            //                                          .Select(x=>new SQLInstance())
                                                      

        }

        public override bool IsMember(string node)
        {
            return false;

        }
    }
}
