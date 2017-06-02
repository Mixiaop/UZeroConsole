﻿using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Mapping
{
    public class RoleMap: UZeroConsoleEntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable(DbConsts.DbTableName.Roles);
            this.HasKey(x => x.Id);
        }
    }
}
