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
        public int HotelId = hotelId;
        public string HotelName = hotelName;
        private readonly List<HotelReview> _reviews = [];

        public IReadOnlyCollection<HotelReview> Reviews => _reviews;

        public void AddRating(GuestInformation guest, int rating, string comment)
        {
            var existingRatingForUser = Reviews.SingleOrDefault(o => o.Guest == guest);
            if (existingRatingForUser is null)
            {
                var review = new HotelReview(HotelId, guest, rating, comment);
                _reviews.Add(review);
            }
            else
            {
                throw new UniqueRatingException("Can not add two reviews for the same stay");
            }
        }

        public decimal GetAverage() => (decimal)Reviews.Average(o => o.Rating);
    }
}