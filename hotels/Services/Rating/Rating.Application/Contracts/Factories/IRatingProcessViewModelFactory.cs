using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;

namespace Rating.Application.Contracts.Factories;

public interface IRatingProcessViewModelFactory
{
    RatingProcessViewModel CreateRatingProcessViewModel (RatingProcess ratings);
}