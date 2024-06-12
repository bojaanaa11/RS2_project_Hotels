using MediatR;
using Microsoft.Extensions.Logging;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Commands.CreateRatingProcess;

public class CreateRatingProcessCommandHandler(IRatingProcessFactory factory,
    IRatingProcessRepository repository,
    ILogger<CreateRatingProcessCommandHandler> logger) : IRequestHandler<CreateRatingProcessCommand, RatingProcessViewModel>
{
    public async Task<RatingProcessViewModel> Handle(CreateRatingProcessCommand request, CancellationToken cancellationToken)
    {
        var rating = factory.CreateRatingProcess(request);
        logger.LogInformation("Created from factory");
        var newRating = await repository.AddRatingProcess(rating.ReservationId, rating.GuestId, rating.HotelId,rating.HotelName);

        logger.LogInformation("Rating process for reservation {HotelId} is successfully created.", newRating.ReservationId);
                       
        return newRating;
    }
}