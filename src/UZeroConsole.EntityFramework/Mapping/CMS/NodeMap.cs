using UZeroConsole.Domain.CMS;

namespace UZeroConsole.EntityFramework.Mapping.CMS
{
    public class NodeMap : UZeroConsoleEntityTypeConfiguration<Node>
    {
        public NodeMap()
        {
            this.ToTable(DbConsts.DbTableName.CMS_Nodes);
            this.HasKey(x => x.Id);
        }
    }
}
