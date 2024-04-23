using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.Common;

namespace Rating.Domain.ValueObjects
{
    public class GuestInformation(int guestId, string guestName, string emailAddress, int reservationId) : ValueObject
    {
        public int GuestId { get; private set; } = guestId;
        public string GuestName { get; private set; } = guestName ?? throw new ArgumentNullException(nameof(guestName));
        public string EmailAddress { get; private set; } = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        public int ReservationId {  get; private set;  } = reservationId;

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return GuestId;
            yield return GuestName;
            yield return EmailAddress;
            yield return ReservationId;
        }
    }
}