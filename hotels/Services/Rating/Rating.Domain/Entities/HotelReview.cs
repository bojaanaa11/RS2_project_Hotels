using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.Aggregates;
using Rating.Domain.Common;
using Rating.Domain.ValueObjects;

namespace Rating.Domain.Entities
{
    public class HotelReview : EntityBase
    {
        public string HotelId { get; private set; }  
        public string GuestId { get; private set; } 
        public string ReservationId { get; private set; }
        //public Guest Guest { get; private set; }
        //public HotelRatingCollection Hotel { get;private set; }
        public RatingProcess RatingProcess { get; private set; }
        public RatingInformation HotelRating {  get; private set; }
        
        public HotelReview(string hotelId, string guestId, string reservationId, RatingProcess ratingProcess, RatingInformation hotelRating)
        {
            HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
            GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
            ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
            RatingProcess = ratingProcess ?? throw new ArgumentNullException(nameof(ratingProcess));
            HotelRating = hotelRating ?? throw new ArgumentNullException(nameof(hotelRating));
        }
       
        public HotelReview(string hotelId, string guestId, string reservationId)
        {
            HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
            GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
            ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));            
        }

        public void SetRating(RatingInformation ratingInformation)
        {
            HotelRating = ratingInformation;
        }

        public int GetRating() => HotelRating.Rating;
        

    }
}