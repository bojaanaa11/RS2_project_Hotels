using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Domain.Entities;

namespace Rating.Application.Contracts.Factories
{
    public interface IHotelReviewFactory
    {
        HotelReview CreateHotelReview(CreateReviewCommand command);
    }
}