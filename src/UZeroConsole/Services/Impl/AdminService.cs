using System;
using System.Collections.Generic;
using System.Linq;
using UPrime.AutoMapper;
using U.Utilities.Security;
using U.Domain.Entities;
using U.Application.Services.Dto;
using U.UI;
using UZeroConsole.Domain;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    /// <summary>
    /// 管理员服务接口实现
    /// </summary>
    public class AdminService : IAdminService
    {

        #region Fields & Ctor
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        #endregion

        #region Admin
        /// <summary>
        /// 根据Id获取单条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        /// <returns></returns>
        public AdminDto Get(int id)
        {
            if (id == 0)
                throw new UserFriendlyException("请传管理员Id过来获取管理员信息");
            return _adminRepository.Get(id).MapTo<AdminDto>();
        }

        /// <summary>
        /// 根据Id获取单条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        /// <returns></returns>
        public Admin GetEntity(int id)
        {
            if (id == 0)
                throw new UserFriendlyException("请传管理员Id过来获取管理员信息");
            return _adminRepository.Get(id);
        }

        /// <summary>
        /// 分页获取管理员信息
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <returns></returns>
        public PagedResultOutput<AdminDto> Search(SearchAdminInput input)
        {
            var query = _adminRepository.GetAll();

            if (input.RoleId > 0)
                query = query.Where(x => x.RoleId == input.RoleId);

            if (!input.Keywords.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Username.Contains(input.Keywords) || x.Name.Contains(input.Keywords));
            }

            query = query.Where(x => x.Username != Admin.AdminUserName);

            var adminCount = query.Count();
            query = query.OrderByDescending(x => x.CreationTime);

            var admins = query.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize);

            var adminListDtos = admins.MapTo<List<AdminDto>>();

            return new PagedResultOutput<AdminDto>(adminCount, adminListDtos);
        }

        /// <summary>
        /// 验证用户名或密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public AdminDto Validation(string username, string password)
        {
            var admin = _adminRepository.FirstOrDefault(x => x.Username == username);
            if (admin.IsNullOrEmpty())
            {
                throw new UserFriendlyException("用户名不存在");
            }

            if (admin.Password != EncriptionHelper.MD5(password))
            {
                throw new UserFriendlyException("用户名或密码有误");
            }

            return admin.MapTo<AdminDto>();
        }

        /// <summary>
        /// 创建一个管理理员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public void Create(string username, string password, string name, int roleId, string remark = "")
        {
            if (_adminRepository.Count(x => x.Username == username) > 0)
                throw new UserFriendlyException("用户名已存在");

            Admin admin = new Admin();
            admin.Username = username;
            admin.Password = EncriptionHelper.MD5(password);
            admin.Name = name;
            admin.RoleId = roleId;
            admin.Remark = remark;
            admin.CreationTime = DateTime.Now;
            admin.LastLoginTime = DateTime.Now;
            _adminRepository.Insert(admin);
        }

        /// <summary>
        /// 创建一个管理员（多角色）
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="roleIds"></param>
        /// <param name="remark"></param>
        public void Create(string username, string password, string name, List<int> roleIds, string remark = "")
        {
            if (_adminRepository.Count(x => x.Username == username) > 0)
                throw new UserFriendlyException("用户名已存在");

            Admin admin = new Admin();
            admin.Username = username;
            admin.Password = EncriptionHelper.MD5(password);
            admin.Name = name;
            admin.RoleId = 0;
            admin.Remark = remark;
            admin.CreationTime = DateTime.Now;
            admin.LastLoginTime = DateTime.Now;
            admin.Id = _adminRepository.InsertAndGetId(admin);
            if (admin.Id > 0 && roleIds != null)
            {
                SetRoles(admin.Id, roleIds);
            }

        }

        /// <summary>
        /// 更新一条管理员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public void Update(int adminId, string name, int roleId, string remark)
        {
            var admin = _adminRepository.Get(adminId);
            if (admin != null)
            {
                admin.Name = name;
                admin.RoleId = roleId;
                admin.Remark = remark;
                _adminRepository.Update(admin);
            }
        }

        /// <summary>
        /// 更新一条管理员信息
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="roleIds"></param>
        /// <param name="remark"></param>
        /// <param name="unoteUsername"></param>
        public void Update(int adminId, string name, List<int> roleIds, string remark, string unoteUsername = "")
        {
            var admin = _adminRepository.Get(adminId);

            if (admin != null)
            {
                admin.Name = name;
                admin.Remark = remark;
                admin.UNoteUsername = unoteUsername;
                _adminRepository.Update(admin);

                if (roleIds  == null)
                {
                    roleIds = new List<int>();
                }

                SetRoles(admin.Id, roleIds);
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="newPassword"></param>
        public void ResetPassword(int adminId, string newPassword)
        {
            var admin = _adminRepository.Get(adminId);

            admin.Password = EncriptionHelper.MD5(newPassword);
            _adminRepository.Update(admin);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ChangePasswordOutput ChangePassword(ChangePasswordInput input)
        {
            var admin = _adminRepository.Get(input.AdminId);
            ChangePasswordOutput output = new ChangePasswordOutput();
            output.Success = true;
            if (admin.Password != EncriptionHelper.MD5(input.OldPassword))
            {
                output.Success = false;
                output.ErrorMessage = "原密码有误";
            }

            if (input.NewPassword.Length < 6)
            {
                output.Success = false;
                output.ErrorMessage = "新密码不能小于6位";
            }

            if (input.NewPassword == input.OldPassword)
            {
                output.Success = false;
                output.ErrorMessage = "新（旧）密码不能相同";
            }

            admin.Password = EncriptionHelper.MD5(input.NewPassword);
            _adminRepository.Update(admin);

            return output;
        }

        /// <summary>
        /// 更新最后更新时间
        /// </summary>
        /// <param name="adminId"></param>
        public void UpdateLastLoginTime(int adminId)
        {
            var admin = _adminRepository.Get(adminId);
            admin.LastLoginTime = DateTime.Now;
            _adminRepository.Update(admin);
        }

        /// <summary>
        /// 删除一条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        public void Delete(int id)
        {
            var admin = _adminRepository.Get(id);
            if (admin.Username == Admin.AdminUserName)
            {
                throw new UserFriendlyException(string.Format("删除失败，[Username：{0}]超级管理员不能删除", admin.Username));
            }
            _adminRepository.Delete(admin);
        }



        #endregion

        #region CorpWeixin
        /// <summary>
        /// 通过企业微信UserId获取管理员信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public AdminDto GetByCorpWeixinUserId(string userId)
        {
            var admin = this._adminRepository.GetAll().Where(x => x.CorpWeixinUserId == userId.Trim()).FirstOrDefault();
            AdminDto res = new AdminDto();
            if (admin != null)
            {
                res = admin.MapTo<AdminDto>();
            }
            return res;
        }

        /// <summary>
        /// 绑定企业微信帐号Id
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="corpWeixinUserId"></param>
        public void BindCorpWeixin(int adminId, string corpWeixinUserId)
        {
            var adminDto = GetByCorpWeixinUserId(corpWeixinUserId);
            if (adminDto == null)
            {
                throw new Exception("企业微信UserId已被绑定到其他帐号");
            }
            var admin = GetEntity(adminId);
            if (admin != null)
            {
                admin.CorpWeixinUserId = corpWeixinUserId;
                this._adminRepository.Update(admin);
            }
        }
        #endregion
        /// <summary>
        /// 为管理员设置角色，设置时会清除原来的角色
        /// </summary>
        /// <param name="adminId">管理员Id</param>
        /// <param name="roleIds">角色Id列表</param>
        public void SetRoles(int adminId, List<int> roleIds)
        {
            if (roleIds == null)
                roleIds = new List<int>();
            _adminRepository.SetRoles(adminId, roleIds);
        }
    }
}
