using System;
using U.Domain.Entities;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个“管理员”
    /// </summary>
    public class Admin : Entity,IHasCreationTime, ISoftDelete
    {
        /// <summary>
        /// 默认管理员的用户名
        /// </summary>
        public const string AdminUserName = "admin";

        public Admin()
        {
            CreationTime = DateTime.Now;
            IsDeleted = false;
        }

        /// <summary>
        ///  昵称（姓名）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 备注（描述）
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public virtual Role Role { get; set; }

    }
}
