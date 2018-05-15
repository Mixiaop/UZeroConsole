using System;
using AutoMapper;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Dto;
using UZeroConsole.Services.Sso.Dto;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Services.Mappers
{
    internal static class CustomDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        public static void CreateMappings()
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal();

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal()
        {
            Action<IMapperConfigurationExpression> configurer = configuration =>
            {

                configuration.CreateMap<Admin, AdminDto>().ReverseMap();
                configuration.CreateMap<Permission, PermissionDto>().ReverseMap();
                configuration.CreateMap<Role, RoleDto>().ReverseMap();
                configuration.CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
                configuration.CreateMap<App, AppDto>().ReverseMap();
                configuration.CreateMap<ActionLog, ActionLogDto>().ReverseMap();
            };
                
        }
    }
}
