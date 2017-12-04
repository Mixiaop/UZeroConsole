using System.Linq;
using System.Collections.Generic;
using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class AdminRepository : UZeroConsoleRepositoryBase<Admin>, IAdminRepository
    {
        private RoleRepository _roleRepository;
        public AdminRepository(UZeroConsoleDbContext databaseProvider, RoleRepository roleRepository) : base(databaseProvider) {
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// 为管理员设置角色，设置时会清除原来的角色
        /// </summary>
        /// <param name="adminId">管理员Id</param>
        /// <param name="roleIds">角色Id列表</param>
        public void SetRoles(int adminId, List<int> roleIds)
        {
            _roleRepository.Context = this.Context;

            var admin = this.Get(adminId);
            if (admin != null) {
                if (admin.Roles != null)
                {
                    admin.Roles.Clear();
                    this.Update(admin); //clear all
                }
                else {
                    admin.Roles = new List<Role>();
                }

                var query = _roleRepository.GetAll().Where(x => roleIds.Contains(x.Id));
                var roleList = query.ToList();
                if (roleList != null) {
                    foreach (var role in roleList)
                        admin.Roles.Add(role);

                    this.Update(admin);
                }
            }
        }
    }
}
