using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.Common;

namespace Rating.Domain.Entities
{
    public class Guest(int guestId, string guestName, string emailAddress, int reservationId) : EntityBase
    {
        public readonly ICollection<HotelReview> hotelReviews = [];

        public int GuestId { get; private set; } = guestId;
        public string GuestName { get; private set; } = guestName ?? throw new ArgumentNullException(nameof(guestName));
        public string EmailAddress { get; private set; } = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        public int ReservationId {  get; private set;  } = reservationId;
    }
}