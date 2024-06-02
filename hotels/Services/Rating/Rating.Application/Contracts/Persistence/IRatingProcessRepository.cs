using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;

namespace Rating.Application.Contracts.Persistence;

public interface IRatingProcessRepository : IAsyncRepository<RatingProcess>
{
    Task<RatingProcessViewModel> AddRatingProcess(string reservationId, string guestId, string hotelId);
    Task<bool> UpdateRatingProcess(string reservationId, string guestId,string hotelId, string status);
    Task<IReadOnlyCollection<RatingProcess>?> GetRatingProcesses(string guestId);
}