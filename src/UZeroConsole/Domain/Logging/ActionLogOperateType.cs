using U.CodeAnnotations;

namespace UZeroConsole.Domain.Logging
{
    /// <summary>
    /// 日志操作类型
    /// </summary>
    public enum ActionLogOperateType
    {
        [EnumAlias("Insert")]
        Insert = 10,
        [EnumAlias("Update")]
        Update = 20,
        [EnumAlias("Query")]
        Query = 30,
        [EnumAlias("Delete")]
        Delete = 40,
        [EnumAlias("Default")]
        None = -1
    }
}
