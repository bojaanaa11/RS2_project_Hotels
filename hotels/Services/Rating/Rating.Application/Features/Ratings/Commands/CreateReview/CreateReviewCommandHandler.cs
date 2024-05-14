using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Persistence;

namespace Rating.Application.Features.Ratings.Commands.CreateReview
{
    public class CreateReviewCommandHandler(IHotelReviewFactory factory,
        IRatingRepository repository,
        ILogger<CreateReviewCommandHandler> logger) : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IHotelReviewFactory _factory = factory;
        private readonly IRatingRepository _repository = repository;
        private readonly ILogger<CreateReviewCommandHandler> _logger = logger;
        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddReviewToCollection(request.HotelId,request);

            _logger.LogInformation("Review is successfully added to collection.");
                       
            return request.HotelId;
        }
    }
}