using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Rating.Application.Features.Ratings.Queries.GetAverageRatingQuery
{
    public class GetAvergaRatingQueryValidator : AbstractValidator<GetAverageRatingQuery>
    {
        public GetAvergaRatingQueryValidator(){
            RuleFor (getAverage => getAverage.HotelId)
            .NotNull()
            .WithMessage("Hotel id can not be null");
        }
    }
}