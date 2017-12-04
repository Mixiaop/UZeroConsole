using UZeroConsole.Domain;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    public static class Extensions
    {
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        /// <returns></returns>
        public static bool IsSuperAdmin(this AdminDto admin)
        {
            return admin.Username == Admin.AdminUserName;
        }
    }
}
