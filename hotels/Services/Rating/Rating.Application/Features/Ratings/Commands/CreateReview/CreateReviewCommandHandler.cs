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
        ILogger<CreateReviewCommandHandler> logger) : IRequestHandler<CreateReviewCommand, bool>
    {
        public async Task<bool> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var success=await repository.AddReviewToCollection(request.HotelId,request);

            logger.LogInformation("Review is successfully added to collection.");
                       
            return success;
        }
    }
}