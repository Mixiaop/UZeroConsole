using U.Application.Services.Dto;

namespace UZeroConsole.Services.Dto
{
    public class RoleDto : EntityDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
