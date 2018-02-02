using System;

namespace UZeroConsole.Monitoring.SQL
{
    public interface ISQLVersioned : IMinVersioned
    {
        string GetFetchSQL(Version v);
    }
}
