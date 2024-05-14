using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Persistence;

namespace Rating.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCollectionCommandHandler(IHotelRatingCollectionFactory factory,
        IRatingRepository repository,
        ILogger<CreateRatingCollectionCommandHandler> logger) : IRequestHandler<CreateRatingCollectionCommand, int>
    {
        private readonly IHotelRatingCollectionFactory _factory = factory;
        private readonly IRatingRepository _repository = repository;
        private readonly ILogger<CreateRatingCollectionCommandHandler> _logger = logger;

        public async Task<int> Handle(CreateRatingCollectionCommand request, CancellationToken cancellationToken)
        {
            var rating = _factory.CreateHotelRatingCollection(request);
            var newRating = await _repository.AddAsync(rating);

            _logger.LogInformation("Rating {HotelId} is successfully created.", newRating.HotelId);
                       
            return newRating.HotelId;
        }
    }
}