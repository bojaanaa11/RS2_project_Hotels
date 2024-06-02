using MediatR;
using Microsoft.Extensions.Logging;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Queries.GetPendingRatingsQuery;

public class GetPendingRatingsQueryHandler : IRequestHandler<GetPendingRatingsQuery, List<RatingProcessViewModel>>
{
    private readonly IRatingProcessRepository _repository;
    private readonly IRatingProcessViewModelFactory _factory;
    private readonly ILogger<GetPendingRatingsQueryHandler> _logger;

    public GetPendingRatingsQueryHandler(IRatingProcessRepository repository, IRatingProcessViewModelFactory factory,
        ILogger<GetPendingRatingsQueryHandler> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<List<RatingProcessViewModel>> Handle(GetPendingRatingsQuery request, CancellationToken cancellationToken)
    {
        var ratings = await _repository.GetRatingProcesses(request.GuestId);
        if (ratings != null)
        {
            var result = ratings.Select(rating => _factory.CreateRatingProcessViewModel(rating)).ToList();
            return result;
        }

        return [];
    }
}