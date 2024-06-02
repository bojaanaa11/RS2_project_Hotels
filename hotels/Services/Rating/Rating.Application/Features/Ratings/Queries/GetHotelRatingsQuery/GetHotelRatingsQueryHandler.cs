using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Queries.GetHotelRatingsQuery
{
    public class GetHotelRatingsQueryHandler : IRequestHandler<GetHotelRatingsQuery, List<HotelReviewViewModel>>
    {
        private readonly IRatingRepository _repository;
        private readonly IHotelReviewViewModelFactory _factory;
        private readonly ILogger<GetHotelRatingsQueryHandler> _logger;

        public GetHotelRatingsQueryHandler(IRatingRepository repository, IHotelReviewViewModelFactory factory,ILogger<GetHotelRatingsQueryHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<List<HotelReviewViewModel>> Handle(GetHotelRatingsQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _repository.GetRatingsByHotel(request.HotelId);
            var result = ratings.Select(rating => _factory.CreateHotelReviewViewModel(rating)).ToList();
            return result;
        }
    }
}