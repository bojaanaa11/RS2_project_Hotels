using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Rating.Application.Features.Ratings.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator(){
            RuleFor (createReview => createReview.GuestId)
            .NotNull()
            .WithMessage("GuestId can not be null");

            RuleFor (createReview => createReview.ReservationId)
            .NotNull()
            .WithMessage("ReservationId can not be null");

            RuleFor (createReview => createReview.HotelId)
            .NotNull()
            .WithMessage("HotelId can not be null");

            RuleFor (createReview => createReview.HotelName)
            .NotNull()
            .WithMessage("Hotel name can not be null");
        }
    }
}