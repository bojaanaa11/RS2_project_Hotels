/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rating.Application.Features.Ratings.Commands.DTOs;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCollectionCommand : IRequest<string>
    {
        public string HotelId { get; set; }
        public IEnumerable<HotelReviewDTO> Reviews {get; set;}
        public IEnumerable<RatingProcessViewModel> Processes {
            get;
            set;
        }
        public CreateRatingCollectionCommand(string hotelId, IEnumerable<HotelReviewDTO> reviews,IEnumerable<RatingProcessViewModel> processes)
        {
            HotelId = hotelId;
            Reviews = reviews;
            Processes = processes;
        }

        public CreateRatingCollectionCommand(string hotelId)
        {
            HotelId = hotelId;
            Reviews = [];
            Processes = [];
        }
       

    }
}*/