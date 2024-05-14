using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rating.Application.Features.Ratings.Commands.DTOs;

namespace Rating.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCollectionCommand : IRequest<int>
    {
        public CreateRatingCollectionCommand(int hotelId, string hotelName, IEnumerable<HotelReviewDTO> reviews)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            Reviews = reviews;
        }

        public CreateRatingCollectionCommand(int hotelId, string hotelName)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            Reviews = [];
        }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public IEnumerable<HotelReviewDTO> Reviews {get; set;}

    }
}