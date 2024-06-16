using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.IdentityModel.Tokens;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;
using Rating.Infrastructure.Persistence;
using Rating.Infrastructure.Persistence.EntityConfigurations;

namespace Rating.Infrastructure.Repositories
{
    public class RatingRepository : RepositoryBase<HotelReview>, IRatingRepository
    {
        public RatingRepository(RatingContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddReviewToCollection(string hotelId, CreateReviewCommand hotelReview)
        {
            var ratingprocesses = _dbContext.RatingProcesses
                .Where(t => t.GuestId == hotelReview.GuestId && t.ReservationId == hotelReview.ReservationId && t.Status == "Pending")
                .ToListAsync();

            if (ratingprocesses.Result.IsNullOrEmpty())
                return false;

            var review = new HotelReview(hotelId,hotelReview.HotelName, hotelReview.GuestId, hotelReview.ReservationId,
                ratingprocesses.Result[0], hotelReview.HotelRating);
            await _dbContext.Ratings.AddAsync(review);
            ratingprocesses.Result[0].Status = "Rated";
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyCollection<HotelReview>> GetRatingsByHotel(string hotelId)
        {
            var result =await _dbContext.Ratings
                .Where(o => o.HotelId == hotelId)
                .ToListAsync();


            return result;
        }

        public async Task<decimal> GetAverageRating(string hotelId)
        {
            try
            {
                var result = await _dbContext.Ratings
                    .Where(o => o.HotelId == hotelId)
                    .AverageAsync(o => o.HotelRating.Rating);
                return (decimal)result;
            }
            catch (InvalidOperationException e)
            {
                return (decimal)0.0;
            }
        }

        public async Task<bool> DeleteHotelReview(string requestGuestId, string requestReservationId)
        {
            var res = await _dbContext.Ratings.Where(o => o.GuestId==requestGuestId && o.ReservationId==requestReservationId).ExecuteDeleteAsync();
            return res != 0;
        }
    }
}
