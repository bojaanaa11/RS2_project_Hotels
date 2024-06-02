/*using FluentValidation;

namespace Rating.Application.Features.Ratings.Commands.CreateRating;

public class CreateRatingCollectionValidator : AbstractValidator<CreateRatingCollectionCommand>
{
    public CreateRatingCollectionValidator()
    {
        RuleFor(createRatingCollection => createRatingCollection.HotelId)
            .NotNull().WithMessage("HotelId can not be null");

    }
}*/