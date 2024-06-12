using Rating.Application.Contracts.Factories;
using Rating.Application.Features.Ratings.Commands.CreateRatingProcess;
using Rating.Domain.Aggregates;

namespace Rating.Infrastructure.Factories;

public class RatingProcessFactory : IRatingProcessFactory
{
    public RatingProcess CreateRatingProcess(CreateRatingProcessCommand command)
    {
        var ratingProcess = new RatingProcess(command.HotelId,command.HotelName,command.ReservationId,command.GuestId,"Pending");
        return ratingProcess;
    }
}