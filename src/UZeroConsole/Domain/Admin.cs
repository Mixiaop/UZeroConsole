using System;
using System.Collections;
using System.Collections.Generic;
using U.Domain.Entities;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个“管理员”
    /// </summary>
    public class Admin : Entity, IHasCreationTime, ISoftDelete
    {
        /// <summary>
        /// 默认管理员的用户名
        /// </summary>
        public const string AdminUserName = "admin";

        public Admin()
        {
            CreationTime = DateTime.Now;
            UNoteUsername = "";
            CorpWeixinUserId = "";
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
        /// UNote用户名
        /// </summary>
        public string UNoteUsername { get; set; }

        /// <summary>
        /// 企业微信用户Id
        /// </summary>
        public string CorpWeixinUserId { get; set; }

        #region IHasCreationTime, ISoftDelete
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }
        #endregion

        /// <summary>
        /// 用户角色
        /// </summary>
        //[Obsolete("多角色会替换之")]
        public virtual Role Role { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        #region Custom
        public IList<int> RoleIds {
            get {
                List<int> roleIds = new List<int>();
                if (Roles != null) {
                    foreach (var r in Roles)
                        roleIds.Add(r.Id);
                }

                return roleIds;
            }
        }
        #endregion
    }
}
