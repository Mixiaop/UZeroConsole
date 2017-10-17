using UZeroConsole.Domain.CMS;
using UZeroConsole.Domain.CMS.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.CMS
{
    public class NodeRepository : UZeroConsoleRepositoryBase<Node>, INodeRepository
    {
        public NodeRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }

        /// <summary>
        /// 重置父节点下所有的节点Last标记
        /// </summary>
        /// <param name="parentId"></param>
        public void RetsetLastNodeAttr(int parentId)
        {
            string sql = string.Format("UPDATE [{0}] SET IsLastNode=0 WHERE ParentId={1}", DbConsts.DbTableName.CMS_Nodes, parentId);
            Context.ExecuteSqlCommand(sql);
        }
    }
}
