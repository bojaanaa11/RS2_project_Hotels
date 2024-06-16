using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Contracts.Factories;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Domain.Entities;
using Rating.Domain.ValueObjects;

namespace Rating.Infrastructure.Factories
{
    public class HotelReviewFactory : IHotelReviewFactory
    {
        public HotelReview CreateHotelReview(CreateReviewCommand command)
        {
            var hotelReview = new HotelReview
            (
                command.HotelId,
                command.HotelName,
                command.GuestId,
                command.ReservationId
            );
            hotelReview.SetRating(command.HotelRating);

            return hotelReview;
        }
    }
}