using System;
using System.Runtime.Serialization;

namespace UZeroConsole.Monitoring
{
    public interface IMinVersioned
    {
        [IgnoreDataMember]
        Version MinVersion { get; }
    }
}
