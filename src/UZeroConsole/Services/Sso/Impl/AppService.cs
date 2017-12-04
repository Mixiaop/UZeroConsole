using System;
using System.Collections.Generic;
using System.Linq;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Domain.Sso.Repositories;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Services.Sso.Impl
{
    public class AppService : ApplicationServiceBase, IAppService
    {
        private readonly IAppRepository _appRepository;
        public AppService(IAppRepository appRepository)
        {
            this._appRepository = appRepository;
        }

        public App Get(int id)
        {
            return _appRepository.Get(id);
        }

        public App GetByKey(string appKey)
        {
            var info = _appRepository.GetAll().Where(x => x.AppKey == appKey.Trim()).FirstOrDefault();
            return info;
        }

        public IList<App> GetAll(bool filterSystem = true) {
            var query = _appRepository.GetAll();
            if (filterSystem) {
                query = query.Where(x => x.IsSystem == false);
            }
            var list = query.OrderByDescending(x => x.CreationTime).ToList();

            return list;
        }

        public PagedResultDto<App> Query(string keywords, int pageIndex = 1, int pageSize = 20)
        {
            keywords = keywords.Trim();
            var query = _appRepository.GetAll();
            if (keywords.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.Name.Contains(keywords) || x.Remark.Contains(keywords));
            }

            query = query.OrderByDescending(x => x.CreationTime);
            var list = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var count = query.Count();

            return new PagedResultDto<App>(count, list);
        }

        public StateOutput CreateOrUpdate(CreateOrUpdateAppInput input)
        {
            StateOutput res = new StateOutput();
            if (!input.Name.IsNotNullOrEmpty())
            {
                res.AddError("名称不能为空");
                return res;
            }
            if (input.ReturnUrl.IsNullOrEmpty()) {
                res.AddError("回调Url不能为空");
                return res;
            }
            if (input.Id == 0)
            {
                //insert
                var app = new App();
                app.Name = input.Name;
                app.Remark = input.Remark;
                app.ReturnUrl = input.ReturnUrl;
                app.AppKey = Guid.NewGuid().ToString().Replace("-", "");
                app.SecretKey = Guid.NewGuid().ToString().Replace("-", "");
                input.Id = _appRepository.InsertAndGetId(app);
            }
            else
            {
                //update
                var app = Get(input.Id);
                if (app != null)
                {
                    app.Name = input.Name;
                    app.Remark = input.Remark;
                    app.ReturnUrl = input.ReturnUrl;

                    _appRepository.Update(app);
                }
            }
            return res;
        }

        public StateOutput Delete(int id)
        {
            StateOutput res = new StateOutput();
            try
            {
                _appRepository.Delete(id);
            }
            catch (Exception ex)
            {
                res.AddError(ex.Message);
            }

            return res;
        }

        public StateOutput DeleteByKey(string appKey)
        {
            StateOutput res = new StateOutput();
            var app = GetByKey(appKey);
            if (app != null)
            {
                _appRepository.Delete(app);
            }
            else
            {
                res.AddError("app not found");
            }

            return res;
        }
    }
}
