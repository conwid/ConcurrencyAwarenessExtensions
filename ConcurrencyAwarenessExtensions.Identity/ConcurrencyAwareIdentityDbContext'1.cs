using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ConcurrencyAwarenessExtensions.Identity
{
    public class ConcurrencyAwareIdentityDbContext<TUser> : IdentityDbContext<TUser> where TUser : IdentityUser
    {
        public ConcurrencyAwareIdentityDbContext() : base() { }
        public ConcurrencyAwareIdentityDbContext( string nameOrConnectionString ) : base( nameOrConnectionString ) { }
        public ConcurrencyAwareIdentityDbContext( DbCompiledModel model ) : base( model ) { }
        public ConcurrencyAwareIdentityDbContext( DbConnection existingConnection, bool contextOwnsConnection ) : base( existingConnection, contextOwnsConnection ) { }
        public ConcurrencyAwareIdentityDbContext( string nameOrConnectionString, DbCompiledModel model ) : base( nameOrConnectionString, model ) { }
        public ConcurrencyAwareIdentityDbContext( DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection ) : base( existingConnection, model, contextOwnsConnection ) { }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
            modelBuilder.Conventions.Add( new ConcurrencyAwareEntityConvention() );
        }
    }
}