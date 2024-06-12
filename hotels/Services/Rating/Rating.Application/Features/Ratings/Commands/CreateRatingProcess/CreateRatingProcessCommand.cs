using MediatR;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;

namespace Rating.Application.Features.Ratings.Commands.CreateRatingProcess;

public class CreateRatingProcessCommand : IRequest<RatingProcessViewModel>
{
    public string HotelId { get; private set; }
    public string HotelName { get; private set; }
    public string ReservationId { get; private set; }
    public string GuestId { get; private set; }
    //public Guest Guest { get;private set; }
    //public HotelRatingCollection Hotel { get; private set; }
    public CreateRatingProcessCommand(){}
    
    /*public CreateRatingProcessCommand(string hotelId, string reservationId, string guestId)
    {
        HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
        ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
        GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
        //Guest = guest ?? throw new ArgumentNullException(nameof(guest));
        //Hotel = hotel ?? throw new ArgumentNullException(nameof(hotel));
       
    }*/
    public CreateRatingProcessCommand(string hotelId,string hotelName, string reservationId, string guestId)
    {
        HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
        HotelName = hotelName ?? throw new ArgumentNullException(nameof(hotelName));
        ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
        GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
    }
}