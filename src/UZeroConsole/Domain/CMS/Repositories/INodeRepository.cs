using U.Domain.Repositories;

namespace UZeroConsole.Domain.CMS.Repositories
{
    public interface INodeRepository : IRepository<Node>
    {
        /// <summary>
        /// 重置父节点下所有的节点Last标记
        /// </summary>
        /// <param name="parentId"></param>
        void RetsetLastNodeAttr(int parentId);
    }
}
