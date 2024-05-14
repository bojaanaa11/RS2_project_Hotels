using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;

namespace Rating.Infrastructure.Persistence
{
    public class RatingContextSeed
    {
        public static async Task SeedAsync(RatingContext ratingContext, ILogger<RatingContextSeed> logger)
        {
            if (!ratingContext.Ratings.Any())
            {
                ratingContext.Ratings.AddRange(GetPreconfiguredRatings());
                await ratingContext.SaveChangesAsync();
                logger.LogInformation("Seeding database associated with context {DbContextName}", nameof(RatingContext));
            }
        }

        private static IEnumerable<HotelRatingCollection> GetPreconfiguredRatings()
        {
            var hotelRatings=new HotelRatingCollection(2,"Tonanti Vr Banja");
            
            hotelRatings.AddRating(1,"Isidora Burmaz","isidoraburmaz@gmail.com",1,10,"Great stay!");
            hotelRatings.AddRating(2,"Marija Micic","marijamicic@gmail.com",2,9,"Lovely stay!");

            return new List<HotelRatingCollection> { hotelRatings };
        }
    }
}