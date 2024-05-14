using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.ValueObjects;

namespace Rating.Application.Features.Ratings.Queries.ViewModels
{
    public class HotelRatingCollectionViewModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public IEnumerable<HotelReviewViewModel> Reviews {get; set;}
    }
}