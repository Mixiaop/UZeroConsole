using U.Domain.Entities;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个控制台“角色”
    /// </summary>
    public class Role : Entity, ISoftDelete
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
