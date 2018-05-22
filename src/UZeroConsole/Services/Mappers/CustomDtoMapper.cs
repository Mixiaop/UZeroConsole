using AutoMapper;
using System;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Services.Dto;
using UZeroConsole.Services.Logging.Dto;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Services.Mappers
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
        {
            base.CreateMap<Permission, PermissionDto>().ReverseMap();
            base.CreateMap<Role, RoleDto>().ReverseMap();
            base.CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
            base.CreateMap<App, AppDto>().ReverseMap();
            base.CreateMap<ActionLog, ActionLogDto>().ReverseMap();
        }
    }
    
}
