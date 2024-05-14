using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rating.Domain.Entities;
using Rating.Domain.ValueObjects;

namespace Rating.Application.Features.Ratings.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<int>
    {
        public CreateReviewCommand(int hotelId, int guestId, Guest hotelGuest, RatingInformation hotelRating)
        {
            HotelId = hotelId;
            GuestId = guestId;
            HotelGuest = hotelGuest;
            HotelRating = hotelRating;
        }

        public int HotelId { get; set; }
        public int GuestId { get; set; }
        public Guest HotelGuest { get; set; }
        public RatingInformation HotelRating { get; set; }
    }
}