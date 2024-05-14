using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Contracts.Factories;
using Rating.Application.Features.Ratings.Commands.CreateRating;
using Rating.Domain.Aggregates;

namespace Rating.Infrastructure.Factories
{
    public class HotelRatingCollectionFactory : IHotelRatingCollectionFactory
    {
        public HotelRatingCollection CreateHotelRatingCollection(CreateRatingCollectionCommand command)
        {
            var hotelRatingCollection = new HotelRatingCollection
                (
                    command.HotelId,
                    command.HotelName
                );

            foreach (var review in command.Reviews)
            {
                hotelRatingCollection.AddRating(review.GuestId,review.GuestName,review.EmailAddress,review.ReservationId,review.Rating,review.Comment);
            }

            return hotelRatingCollection;
        }
    }
}