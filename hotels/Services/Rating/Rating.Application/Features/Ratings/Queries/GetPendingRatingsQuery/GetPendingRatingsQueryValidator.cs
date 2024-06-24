using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Rating.Application.Features.Ratings.Queries.GetPendingRatingsQuery
{
    public class GetPendingRatingsQueryValidator : AbstractValidator<GetPendingRatingsQuery>
    {
        public GetPendingRatingsQueryValidator(){
            RuleFor(ratings => ratings.GuestId)
            .NotEmpty()
            .WithMessage("Guest id can not be empty")
            .NotNull()
            .WithMessage("Guest id can not be null");
        }
    }
}