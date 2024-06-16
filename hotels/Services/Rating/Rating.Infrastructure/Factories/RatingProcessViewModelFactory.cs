using Rating.Application.Contracts.Factories;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;

namespace Rating.Infrastructure.Factories;

public class RatingProcessViewModelFactory : IRatingProcessViewModelFactory
{
    public RatingProcessViewModel CreateRatingProcessViewModel(RatingProcess ratings)
    {
        var ratingProcessViewModel = new RatingProcessViewModel
        {
            ReservationId = ratings.ReservationId,
            GuestId = ratings.GuestId,
            HotelId = ratings.HotelId,
            HotelName = ratings.HotelName,
            Status = ratings.Status
        };
        return ratingProcessViewModel;

    }
}