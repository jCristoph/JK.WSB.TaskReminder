using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JK.WSB.TaskReminder.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (e.State is EntityState.Added or EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).ModifiedOn = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreatedOn = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Step> Steps { get; set; }
    }
}
