using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System.Linq;

namespace ConcurrencyAwarenessExtensions
{
    public class ConcurrencyAwareEntityConvention : Convention
    {
        public ConcurrencyAwareEntityConvention()
        {
            this.Types<IConcurrencyAwareEntity>()
                .Configure(config => config.Property(e => e.RowVersion).IsRowVersion());
        }
    }
}
