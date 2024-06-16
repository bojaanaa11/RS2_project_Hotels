using Rating.Domain.Common;
using Rating.Domain.Entities;

namespace Rating.Domain.Aggregates;

public class RatingProcess : AggregateRoot
{
    public string HotelId { get; private set; }
    public string HotelName { get; private set; }
    public string ReservationId { get; private set; }
    public string GuestId { get; private set; }
    public string Status { get; set; }
    public HotelReview? Review { get; set; }

    public RatingProcess(string hotelId,string hotelName, string reservationId, string guestId, string status, HotelReview? review)
    {
        HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
        ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
        Review = review;
        HotelName = hotelName ?? throw new ArgumentNullException(nameof(hotelName));
    }

    public RatingProcess(string hotelId,string hotelName, string reservationId, string guestId, string status)
    {
        HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
        ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
        HotelName = hotelName ?? throw new ArgumentNullException(nameof(hotelName));
    }
}