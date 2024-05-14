using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;
using Rating.Infrastructure.Persistence;
using Rating.Infrastructure.Persistence.EntityConfigurations;

namespace Rating.Infrastructure.Repositories
{
    public class RatingRepository : RepositoryBase<HotelRatingCollection>, IRatingRepository
    {
        public RatingRepository(RatingContext dbContext) : base(dbContext)
        {
        }

        public async Task AddReviewToCollection(int hotelId, CreateReviewCommand hotelReview)
        {
            HotelRatingCollection? hotel = await _dbContext.FindAsync<HotelRatingCollection>(hotelId);
            if(hotel == null){
                return;
            } else {
                hotel.AddRating(hotelReview.HotelGuest.GuestId,
                    hotelReview.HotelGuest.GuestName,
                    hotelReview.HotelGuest.EmailAddress,
                    hotelReview.HotelGuest.ReservationId,
                    hotelReview.HotelRating.Rating,
                    hotelReview.HotelRating.Comment
                    );
            }
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<HotelReview>> GetRatingsByHotel(string hotelName)
        {
            var result =await _dbContext.Ratings
                .Where(o => o.HotelName == hotelName)
                .SelectMany(o => o.Reviews)
                .ToListAsync();


            return result;
        }
    }
}
