/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.ValueObjects;

namespace Rating.Application.Features.Ratings.Queries.ViewModels
{
    public class HotelRatingCollectionViewModel
    {
        public int Id { get; set; }
        public string HotelId { get; set; }
        public string? HotelName { get; set; }
        public IEnumerable<HotelReviewViewModel> Reviews {get; set;}

        public HotelRatingCollectionViewModel(int id, string hotelId,
            IEnumerable<HotelReviewViewModel> reviews, string? hotelName)
        {
            Id = id;
            HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
            Reviews = reviews ?? throw new ArgumentNullException(nameof(reviews));
            HotelName = hotelName;
        }
        public HotelRatingCollectionViewModel(int id, string hotelId, string? hotelName)
        {
            Id = id;
            HotelId = hotelId ?? throw new ArgumentNullException(nameof(hotelId));
            HotelName = hotelName;
            Reviews = [];
        }
    }
}*/