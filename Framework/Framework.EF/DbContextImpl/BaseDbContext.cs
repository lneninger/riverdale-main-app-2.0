using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Framework.EF.DbContextImpl.Persistance;

namespace Framework.EF.DbContextImpl
{
    public class BaseDbContext : DbContext
    {
        public override int SaveChanges()
        {
            var changed = this.ChangeTracker.Entries<ITrackChangesEntity>();

            foreach (var changedEntity in changed.Where(o => o.State == EntityState.Added))
            {
                ((ITrackChangesEntity)changedEntity.Entity).CreatedAt = DateTime.UtcNow;
            }

            foreach (var changedEntity in changed.Where(o => o.State == EntityState.Modified))
            {
                ((ITrackChangesEntity)changedEntity.Entity).UpdatedAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
