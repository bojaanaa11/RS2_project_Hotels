using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;

namespace Rating.Application.Contracts.Persistence
{
    public interface IRatingRepository : IAsyncRepository<HotelReview>
    {
        Task<IReadOnlyCollection<HotelReview>> GetRatingsByHotel(string hotelId);
        Task<bool> AddReviewToCollection(string hotelId, CreateReviewCommand hotelReview);

        Task<decimal> GetAverageRating(string hotelId);
        Task<bool> DeleteHotelReview(string hotelId);
    }
}