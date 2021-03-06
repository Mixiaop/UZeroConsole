﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Config;

namespace UZeroConsole.Services.Config
{
    public interface IConfigService : IApplicationService
    {
        #region Projects
        PagedResultDto<ConfigProject> QueryProjects(string keywords = "", int pageIndex = 1, int pageSize = 20);
        ConfigProject GetProjectById(int pid);

        ConfigProject InsertProject(ConfigProject project);

        void UpdateProject(ConfigProject project);

        void DeleteProject(ConfigProject project);
        #endregion

        #region Objects
        ConfigObject InsertObject(ConfigObject obj);

        void UpdateObject(ConfigObject obj);

        void DeleteObject(ConfigObject obj);

        PagedResultDto<ConfigObject> QueryObjects(int projectId = 0, string keywords = "", int pageIndex = 1, int pageSize = 20);
        #endregion

        #region Attrs
        #endregion
    }
}
