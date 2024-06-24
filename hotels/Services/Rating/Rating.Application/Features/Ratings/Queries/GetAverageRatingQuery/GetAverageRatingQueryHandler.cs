using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Queries.GetAverageRatingQuery
{
    public class GetAverageRatingQueryHandler : IRequestHandler<GetAverageRatingQuery, decimal>
    {
        private readonly IRatingRepository _repository;
        private readonly ILogger<GetAverageRatingQueryHandler> _logger;

        public GetAverageRatingQueryHandler(IRatingRepository repository, ILogger<GetAverageRatingQueryHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<decimal> Handle(GetAverageRatingQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAverageRating(request.HotelId);
            _logger.LogInformation("Average rating is "+result.ToString());
            return result;
        }
    }
}