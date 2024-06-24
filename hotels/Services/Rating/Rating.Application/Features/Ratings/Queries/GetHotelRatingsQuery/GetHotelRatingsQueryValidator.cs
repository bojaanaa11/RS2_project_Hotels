using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Rating.Application.Features.Ratings.Queries.GetHotelRatingsQuery
{
    public class GetHotelRatingsQueryValidator : AbstractValidator<GetHotelRatingsQuery>
    {
        public GetHotelRatingsQueryValidator() {
            RuleFor(ratings => ratings.HotelId)
            .NotNull()
            .WithMessage("Hotel id can not be null")
            .NotEmpty()
            .WithMessage("Hotel id can not be empty");
        }
    }
}