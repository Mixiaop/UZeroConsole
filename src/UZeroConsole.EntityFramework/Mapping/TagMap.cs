using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Mapping
{
    public partial class TagMap : UZeroConsoleEntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            this.ToTable(DbConsts.DbTableName.Tags);
            this.HasKey(x => x.Id);

            this.Ignore(x => x.Type);
        }
    }
}
