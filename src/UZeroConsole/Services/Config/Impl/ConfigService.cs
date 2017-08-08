using System.Linq;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Config;
using UZeroConsole.Domain.Config.Repositories;

namespace UZeroConsole.Services.Config.Impl
{
    public class ConfigService : ApplicationBase, IConfigService
    {
        private readonly IConfigProjectRepository _projectRepository;
        private readonly IConfigObjectRepository _objectRepository;
        private readonly IConfigAttrRepository _attrRepository;
        public ConfigService(IConfigProjectRepository projectRepository, IConfigObjectRepository objectRepository, IConfigAttrRepository attrRepository) {
            _projectRepository = projectRepository;
            _objectRepository = objectRepository;
            _attrRepository = attrRepository;
        }

        #region Projects
        public PagedResultDto<ConfigProject> QueryProjects(string keywords = "", int pageIndex = 1, int pageSize = 20) {
            var query = _projectRepository.GetAll();
            if (keywords.IsNotNullOrEmpty()) {
                query = query.Where(x => x.Name.Contains(keywords) || x.Desc.Contains(keywords));
            }

            query = query.OrderByDescending(x => x.CreationTime);

            var count = query.Count();
            var list = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagedResultDto<ConfigProject>(count, list);
        }

        public ConfigProject GetProjectById(int pid) {
            return _projectRepository.Get(pid);
        }

        public ConfigProject InsertProject(ConfigProject project)
        {
            project.Id = _projectRepository.InsertAndGetId(project);

            return project;
        }

        public void UpdateProject(ConfigProject project) {
            _projectRepository.Update(project);
        }

        public void DeleteProject(ConfigProject project) {
            _projectRepository.Delete(project);
        }
        #endregion

        #region Objects
        public ConfigObject InsertObject(ConfigObject obj) {
            obj.Id = _objectRepository.InsertAndGetId(obj);
            return obj;
        }

        public void UpdateObject(ConfigObject obj) {
            _objectRepository.Update(obj);
        }

        public void DeleteObject(ConfigObject obj) {
            _objectRepository.Delete(obj);
        }

        public PagedResultDto<ConfigObject> QueryObjects(int projectId = 0, string keywords = "", int pageIndex = 1, int pageSize = 20) {
            var query = _objectRepository.GetAll();
            if (projectId > 0) {
                query = query.Where(x => x.ProjectId == projectId);
            }
            if (keywords.IsNotNullOrEmpty()) {
                query = query.Where(x => x.Name.Contains(keywords));
            }

            query = query.OrderByDescending(x => x.CreationTime);
            var count = query.Count();
            var list = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResultDto<ConfigObject>(count, list);
        }
        #endregion

        #region Attrs
        #endregion
    }
}
