using System.Collections.Generic;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Services.Sso
{
    /// <summary>
    /// Sso应用服务 
    /// </summary>
    public interface IAppService : IApplicationService
    {
        App Get(int id);

        App GetByKey(string appKey);

        IList<App> GetAll(bool filterSystem = true);

        PagedResultDto<App> Query(string keywords, int pageIndex = 1, int pageSize = 20);

        StateOutput CreateOrUpdate(CreateOrUpdateAppInput input);

        StateOutput Delete(int id);

        StateOutput DeleteByKey(string appKey);
    }
}
