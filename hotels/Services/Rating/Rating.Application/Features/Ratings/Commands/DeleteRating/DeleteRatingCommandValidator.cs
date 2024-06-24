using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Rating.Application.Features.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommandValidator : AbstractValidator<DeleteRatingCommand>
    {
        public DeleteRatingCommandValidator(){
            RuleFor(deleteRating => deleteRating.HotelId)
            .NotNull()
            .WithMessage("Hotel id can not be null");
        }
    }
}