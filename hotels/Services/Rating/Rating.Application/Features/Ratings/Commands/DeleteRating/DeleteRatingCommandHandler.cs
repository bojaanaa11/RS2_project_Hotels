using MediatR;
using Microsoft.Extensions.Logging;
using Rating.Application.Contracts.Persistence;

namespace Rating.Application.Features.Ratings.Commands.DeleteRating;

public class DeleteRatingCommandHandler(IRatingRepository repository,
    ILogger<DeleteRatingCommandHandler> logger) : IRequestHandler<DeleteRatingCommand, bool>
{
    public Task<bool> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
    {
        var res = repository.DeleteHotelReview(request.GuestId,request.ReservationId);
        return res;
    }
}
