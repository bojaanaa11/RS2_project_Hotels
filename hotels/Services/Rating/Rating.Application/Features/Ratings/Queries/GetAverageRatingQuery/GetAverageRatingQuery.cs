using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rating.Application.Features.Ratings.Queries.ViewModels;

namespace Rating.Application.Features.Ratings.Queries.GetAverageRatingQuery
{
    public class GetAverageRatingQuery : IRequest<decimal>
    {
        public string HotelName { get; set; }

        public GetAverageRatingQuery(string hotelName){
            HotelName = hotelName ?? throw new ArgumentNullException(nameof(hotelName));
        }
    }
}