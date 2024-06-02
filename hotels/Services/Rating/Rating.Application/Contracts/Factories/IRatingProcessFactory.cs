using Rating.Application.Features.Ratings.Commands.CreateRatingProcess;
using Rating.Domain.Aggregates;

namespace Rating.Application.Contracts.Factories;

public interface IRatingProcessFactory
{
    RatingProcess CreateRatingProcess(CreateRatingProcessCommand command);
    
}