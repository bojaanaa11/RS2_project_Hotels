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
        public string HotelId { get; set; }

        public GetAverageRatingQuery(string hotelId){
            HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
        }
    }
}