using U.Application.Services.Dto;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Services.Dto
{
    public class RoleDto : EntityDto
    {
        public int SsoAppId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public AppDto SsoApp { get; set; }
    }
}
