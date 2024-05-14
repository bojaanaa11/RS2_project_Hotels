using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Features.Ratings.Commands.CreateRating;
using Rating.Domain.Aggregates;

namespace Rating.Application.Contracts.Factories
{
    public interface IHotelRatingCollectionFactory
    {
        HotelRatingCollection CreateHotelRatingCollection(CreateRatingCollectionCommand command);
    }
}