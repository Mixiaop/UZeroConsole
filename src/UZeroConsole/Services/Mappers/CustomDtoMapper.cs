﻿using AutoMapper;
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
            Mapper.CreateMap<Admin, AdminDto>().ReverseMap();
            Mapper.CreateMap<Permission, PermissionDto>().ReverseMap();
            Mapper.CreateMap<Role, RoleDto>().ReverseMap();
            Mapper.CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
            Mapper.CreateMap<App, AppDto>().ReverseMap();
            Mapper.CreateMap<ActionLog, ActionLogDto>().ReverseMap();
        }
    }
}
