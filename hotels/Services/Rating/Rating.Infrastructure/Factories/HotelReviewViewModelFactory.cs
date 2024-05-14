using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Contracts.Factories;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Entities;

namespace Rating.Infrastructure.Factories
{
    public class HotelReviewViewModelFactory : IHotelReviewViewModelFactory
    {
        

        public HotelReviewViewModel CreateHotelReviewViewModel(HotelReview hotelReview)
        {
            var hotelReviewViewModel = new HotelReviewViewModel
            {
                Id=hotelReview.Id,
                HotelId=hotelReview.HotelId,
                GuestId=hotelReview.GuestId,  
                //HotelGuest=hotelReview.HotelGuest,
                Rating=hotelReview.HotelRating.Rating,
                Comment=hotelReview.HotelRating.Comment,
                RatingDate=hotelReview.HotelRating.RatingDate
            };

            return hotelReviewViewModel;
        }

    }
}