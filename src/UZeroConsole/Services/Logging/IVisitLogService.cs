using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U.Application.Services;

namespace UZeroConsole.Services.Logging
{
    public interface IVisitLogService : IApplicationService
    {
        void Insert(string appKey, string visitor, string visitorId, string ip, string url, string userAgent);
    }
}
