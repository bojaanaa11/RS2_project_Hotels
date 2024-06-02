/*using System;
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
        ILogger<CreateRatingCollectionCommandHandler> logger) : IRequestHandler<CreateRatingCollectionCommand, string>
    {
        public async Task<string> Handle(CreateRatingCollectionCommand request, CancellationToken cancellationToken)
        {
            var rating = factory.CreateHotelRatingCollection(request);
            var newRating = await repository.AddAsync(rating);

            logger.LogInformation("Rating {HotelId} is successfully created.", newRating.HotelId);
                       
            return newRating.HotelId;
        }
    }
}*/