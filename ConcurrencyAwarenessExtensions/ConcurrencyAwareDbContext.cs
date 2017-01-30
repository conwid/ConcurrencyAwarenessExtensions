using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace ConcurrencyAwarenessExtensions
{
    public class ConcurrencyAwareDbContext : DbContext
    {

        public ConcurrencyAwareDbContext( string nameOrConnectionString ) : base( nameOrConnectionString ) { }

        public ConcurrencyAwareDbContext( string nameOrConnectionString, DbCompiledModel model ) : base( nameOrConnectionString, model ) { }

        public ConcurrencyAwareDbContext( DbConnection existingConnection, bool contextOwnsConnection ) : base( existingConnection, contextOwnsConnection ) { }

        public ConcurrencyAwareDbContext( ObjectContext objectContext, bool dbContextOwnsObjectContext ) : base( objectContext, dbContextOwnsObjectContext ) { }

        public ConcurrencyAwareDbContext( DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection ) : base( existingConnection, model, contextOwnsConnection ) { }

        protected ConcurrencyAwareDbContext() : base() { }

        protected ConcurrencyAwareDbContext( DbCompiledModel model ) : base( model ) { }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );         
            modelBuilder.Conventions.Add( new ConcurrencyAwareEntityConvention() );           
        }
    }
}