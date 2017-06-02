using System;
using AjaxPro;
using U;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.AjaxServices.UZero
{
    /// <summary>
    /// 角色服务
    /// </summary>
    [AjaxNamespace("RoleService")]
    public partial class RoleService : System.Web.UI.Page
    {
        private readonly IRoleService _roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [AjaxMethod]
        public void Insert(InsertOrUpdateRoleInput input)
        {
            _roleService.Insert(input);
        }

        [AjaxMethod]
        public void Update(InsertOrUpdateRoleInput input)
        {
            _roleService.Update(input);
        }

        [AjaxMethod]
        public void Delete(int roleId)
        {
            _roleService.Delete(roleId);
        }

        [AjaxMethod]
        public RoleDto Get(int roleId)
        {
            return _roleService.Get(roleId);
        }
    }
}