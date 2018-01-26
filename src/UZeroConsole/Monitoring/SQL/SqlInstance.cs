using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UZeroConsole.Configuration.Monitoring;

namespace UZeroConsole.Monitoring.SQL
{
    public partial class SQLInstance : PollNode
    {
        public string ObjectName { get; internal set; }
        protected string ConnectionString { get; set; }
        protected SQLSettings.Instance Settings { get; }

        public SQLInstance(SQLSettings.Instance settings) : base(settings.Name)
        {
            Settings = settings;
            ConnectionString = settings.ConnectionString.IsNullOrEmpty() ? Current.Settings.SQL.DefaultConnectionString.Replace("$ServerName$", settings.Name) : settings.ConnectionString;
            //性能计数
            var csb = new SqlConnectionStringBuilder(ConnectionString);
            var parts = csb.DataSource?.Split(StringSplits.BackSlash);
            if (Settings.ObjectName.IsNotNullOrEmpty())
            {
                ObjectName = settings.ObjectName;
            }
            else {
                ObjectName = parts?.Length == 2 ? "MSSQL$" + parts[1].ToUpper() : "SQLServer";
            }
        }


    }
}
