﻿using System;
using U.Application.Services.Dto;
using UPrime.AutoMapper;
using UZeroConsole.Domain;

namespace UZeroConsole.Services.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto
    {
        public int SsoAppId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// URL链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 父级权限Id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 父级权限
        /// </summary>
        public PermissionDto Parent { get; set; }

        /// <summary>
        /// Level 
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
