using System;
using AjaxPro;
using U;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.AjaxServices.UZero
{
    /// <summary>
    /// 权限异步服务
    /// </summary>
    [AjaxNamespace("PermissionService")]
    public partial class PermissionService : System.Web.UI.Page
    {
        private readonly IPermissionsService _permissionService = UPrimeEngine.Instance.Resolve<IPermissionsService>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [AjaxMethod]
        public void Insert(InsertOrUpdatePermissionInput input)
        {
            _permissionService.Insert(input);
        }

        [AjaxMethod]
        public void Update(InsertOrUpdatePermissionInput input)
        {
            _permissionService.Update(input);
        }

        [AjaxMethod]
        public void Delete(int permissionId)
        {
            _permissionService.Delete(permissionId);
        }

        [AjaxMethod]
        public PermissionDto Get(int permissionId)
        {
            return _permissionService.Get(permissionId);
        }
    }
}