using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Rating.Application.Features.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest<bool>
    {
        public string HotelId { get; private set; }
        public DeleteRatingCommand(string hotelId)
        {
            HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
        }      
        
    }
}