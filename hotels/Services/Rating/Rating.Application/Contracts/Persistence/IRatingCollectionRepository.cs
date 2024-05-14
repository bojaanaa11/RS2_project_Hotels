using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;

namespace Rating.Application.Contracts.Persistence
{
    public interface IRatingRepository : IAsyncRepository<HotelRatingCollection>
    {
        //Interfejs za rating repo
        Task<IReadOnlyCollection<HotelReview>> GetRatingsByHotel(string hotelName);
        Task AddReviewToCollection(int hotelId,CreateReviewCommand hotelReview);
    }
}