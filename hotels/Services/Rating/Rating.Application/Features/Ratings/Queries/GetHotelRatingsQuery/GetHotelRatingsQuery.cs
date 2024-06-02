using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Queries.GetHotelRatingsQuery
{
    public class GetHotelRatingsQuery : IRequest<List<HotelReviewViewModel>>
    {
        public string HotelId { get; set; }

        public GetHotelRatingsQuery(string hotelId){
            HotelId = hotelId?? throw new ArgumentNullException(nameof(hotelId));
        }
    }
}