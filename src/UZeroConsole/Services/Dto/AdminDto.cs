using System.Collections;
using System.Collections.Generic;
using U.Application.Services.Dto;
using System;

namespace UZeroConsole.Services.Dto
{
    public class AdminDto : CreationAuditedEntityDto
    {
        /// <summary>
        ///  昵称（姓名）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        public RoleDto Role { get; set; }

        /// <summary>
        /// 备注（描述）
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        
        public string UNoteUsername { get; set; }

        public ICollection<RoleDto> Roles { get; set; }

        public IList<int> RoleIds {
            get {
                List<int> ids = new List<int>();
                if (Roles != null) {
                    foreach (var role in Roles) {
                        ids.Add(role.Id);
                    }
                }
                return ids;
            }
        }

    }
}
