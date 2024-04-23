using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.Common;
using Rating.Domain.ValueObjects;

namespace Rating.Domain.Entities
{
    public class HotelReview(int hotelId, GuestInformation guest, int rating, string comment) : EntityBase
    {
        public int HotelId { get; set; }  = hotelId;
        public GuestInformation Guest { get; set; }  = guest ?? throw new ArgumentNullException(nameof(guest));
        
        public int Rating { get; set; } = rating;
        public string Comment { get; set; } = comment ?? throw new ArgumentNullException(nameof(comment));
    }
}