using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rating.Domain.Aggregates;
using Rating.Domain.Common;
using Rating.Domain.Entities;
using Rating.Infrastructure.Persistence.EntityConfigurations;

namespace Rating.Infrastructure.Persistence
{
    public class RatingContext : DbContext
    {
        public DbSet<HotelReview> Ratings { get; set; } = null!;
        public DbSet<RatingProcess> RatingProcesses { get; set; } = null!;

        public RatingContext(DbContextOptions options) 
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "isidora";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "isidora";
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new GuestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new RatingCollectionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RatingProcessTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}