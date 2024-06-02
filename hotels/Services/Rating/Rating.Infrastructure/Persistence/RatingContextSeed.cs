using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;
using Rating.Domain.ValueObjects;

namespace Rating.Infrastructure.Persistence
{
    public class RatingContextSeed
    {
        public static async Task SeedAsync(RatingContext ratingContext, ILogger<RatingContextSeed> logger)
        {
            if (!ratingContext.RatingProcesses.Any())
            {
                ratingContext.RatingProcesses.AddRange(GetPreconfiguredRatingProcesses());
                await ratingContext.SaveChangesAsync();
                logger.LogInformation("Seeding database associated with context {DbContextName}", nameof(RatingContext));
            }
            /*if (!ratingContext.Ratings.Any())
            {
                ratingContext.Ratings.AddRange(GetPreconfiguredRatings());
                await ratingContext.SaveChangesAsync();
                logger.LogInformation("Seeding database associated with context {DbContextName}", nameof(RatingContext));
            }*/
        }

        private static IEnumerable<RatingProcess> GetPreconfiguredRatingProcesses()
        {
            //Guest guest = new Guest("1", "Marko", "marko");
            //var hotelRatings=new HotelRatingCollection("1");
            var ratingProcess = new RatingProcess("1", "1", "1", "Pending");
            
            return new List<RatingProcess> { ratingProcess };
        }

        private static IEnumerable<HotelReview> GetPreconfiguredRatings(RatingProcess process)
        {
            //Guest guest = new Guest("1", "Marko", "marko", "1");
            //var hotelRatings=new HotelRatingCollection("2");
            var hotelRating = new RatingInformation(10, "Great stay!", DateTime.Now);
            var rating = new HotelReview("1", "1", "1", process, hotelRating);
          

            return new List<HotelReview> { rating };
        }
    }
}