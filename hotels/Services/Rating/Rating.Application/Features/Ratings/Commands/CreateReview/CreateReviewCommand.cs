using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;
using Rating.Domain.ValueObjects;

namespace Rating.Application.Features.Ratings.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<bool>
    {
        
        public string HotelId { get; private set; }
        public string HotelName { get; private set; }
        public string GuestId { get; private set; }
        public string ReservationId { get; private set; }
        //public Guest Guest { get; private set; }
        //public HotelRatingCollection Hotel { get; private set; }
        public RatingInformation HotelRating { get; private set; }
        public CreateReviewCommand(string hotelId,string hotelName, string guestId, RatingInformation hotelRating, string reservationId)
        {
            HotelId = hotelId ?? throw new ArgumentNullException(hotelId);
            HotelName=hotelName ?? throw new ArgumentNullException(hotelName);
            GuestId = guestId ?? throw new ArgumentNullException(guestId);
            HotelRating = hotelRating;
            ReservationId = reservationId ?? throw new ArgumentNullException(reservationId);
            //Guest = guest;
            //Hotel = hotel;
        }


    }
}