using U.Application.Services.Dto;

namespace UZeroConsole.Services.Dto
{
    public class RolePermissionDto : EntityDto
    {
        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public RoleDto Role { get; set; }

        public PermissionDto Permission { get; set; }
    }
}

