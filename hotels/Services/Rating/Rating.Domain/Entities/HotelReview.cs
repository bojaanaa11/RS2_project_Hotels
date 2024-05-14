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
        

        public int HotelId { get; private set; }  
        public int GuestId { get; private set; } 
        public Guest HotelGuest { get; set; } 
        
        public HotelRatingCollection RatingCollection { get; set; }
        
        public RatingInformation HotelRating {  get; set; }

        public HotelReview(int hotelId, int guestId)
        {
            HotelId = hotelId;
            GuestId = guestId;
        }

        public int GetRating() => HotelRating.Rating;
        

    }
}