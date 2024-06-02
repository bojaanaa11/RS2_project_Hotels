using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Rating.Application.Features.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest<bool>
    {
        public DeleteRatingCommand(string reservationId, string guestId)
        {
            ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
            GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
        }

        public string ReservationId { get; set; }
        public string GuestId { get; set; }
        
        
    }
}