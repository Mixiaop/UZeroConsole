using System;
using System.Data.Entity.ModelConfiguration;

namespace UZeroConsole.EntityFramework.Mapping
{
    public abstract class UZeroConsoleEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected UZeroConsoleEntityTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }
    }
}
