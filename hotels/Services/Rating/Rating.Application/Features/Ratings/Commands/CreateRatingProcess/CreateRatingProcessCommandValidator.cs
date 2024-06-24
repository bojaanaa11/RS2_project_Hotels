using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Rating.Application.Features.Ratings.Commands.CreateRatingProcess
{
    public class CreateRatingProcessCommandValidator : AbstractValidator<CreateRatingProcessCommand>
    {
        public CreateRatingProcessCommandValidator() {
            RuleFor (createRatingProcess => createRatingProcess.GuestId)
            .NotNull()
            .WithMessage("GuestId can not be null");

            RuleFor (createRatingProcess => createRatingProcess.ReservationId)
            .NotNull()
            .WithMessage("ReservationId can not be null");

            RuleFor (createRatingProcess => createRatingProcess.HotelId)
            .NotNull()
            .WithMessage("HotelId can not be null");

            RuleFor (createRatingProcess => createRatingProcess.HotelName)
            .NotNull()
            .WithMessage("Hotel name can not be null");            
        }
        
    }
}