using U.Application.Services.Dto;
using UPrime.AutoMapper;
using UZeroConsole.Domain;

namespace UZeroConsole.Services.Dto
{
    [AutoMapFrom(typeof(RolePermission))]
    public class RolePermissionDto : EntityDto
    {
        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public RoleDto Role { get; set; }

        public PermissionDto Permission { get; set; }
    }
}

