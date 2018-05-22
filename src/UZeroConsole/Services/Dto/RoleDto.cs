using U.Application.Services.Dto;
using UPrime.AutoMapper;
using UZeroConsole.Domain;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Services.Dto
{
    [AutoMapFrom(typeof(Role))]
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
