using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.Common;
using Rating.Domain.Entities;
using Rating.Domain.Exceptions;
using Rating.Domain.ValueObjects;

namespace Rating.Domain.Aggregates
{
    public class HotelRatingCollection(int hotelId, string hotelName) : AggregateRoot
    {
        public int HotelId { get; private set; } = hotelId;
        public string HotelName { get; private set; } = hotelName;
        private readonly List<HotelReview> _reviews = [];

        public IReadOnlyCollection<HotelReview> Reviews => _reviews;

        public void AddRating(int guestId, string guestName, string emailAddress,int reservationId, int rating, string comment)
        {
            Guest guest=new Guest(guestId,guestName,emailAddress,reservationId);
            RatingInformation ratingInfo=new RatingInformation(rating,comment,null);
            var existingRatingForUser = Reviews.SingleOrDefault(o => o.HotelGuest == guest);
            if (existingRatingForUser is not null)
            {
                throw new UniqueRatingException("Can not add two reviews for the same stay");
            }
            else
            {
                var review = new HotelReview(HotelId,guestId){
                    HotelGuest = guest,
                    HotelRating=ratingInfo
                };
                _reviews.Add(review);
            }
        }

        public decimal GetAverage() => (decimal)Reviews.Average(o => o.GetRating());
    }
}