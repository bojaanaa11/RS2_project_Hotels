using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Rating.Infrastructure.Persistence
{
    public class DesignTimeRatingContextFactory : IDesignTimeDbContextFactory<RatingContext>
    {
        public RatingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RatingContext>();
            optionsBuilder.UseSqlServer();
            return new RatingContext(optionsBuilder.Options);
        }
    }

}