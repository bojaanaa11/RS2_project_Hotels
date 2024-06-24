using MediatR;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Commands.CreateRatingProcess;

public class CreateRatingProcessCommand : IRequest<RatingProcessViewModel>
{
    public string HotelId { get; private set; }
    public string HotelName { get; private set; }
    public string ReservationId { get; private set; }
    public string GuestId { get; private set; }
    public CreateRatingProcessCommand(){}

    public CreateRatingProcessCommand(string hotelId,string hotelName, string reservationId, string guestId)
    {
        HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
        HotelName = hotelName ?? throw new ArgumentNullException(nameof(hotelName));
        ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
        GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
    }
}