using MediatR;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Queries.GetPendingRatingsQuery;

public class GetPendingRatingsQuery : IRequest<List<RatingProcessViewModel>>
{
    public string GuestId { get; set; }
    public GetPendingRatingsQuery(string guestId)
    {
        GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
    }
}