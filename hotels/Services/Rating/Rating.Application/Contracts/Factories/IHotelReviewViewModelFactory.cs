using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Entities;

namespace Rating.Application.Contracts.Factories
{
    public interface IHotelReviewViewModelFactory
    {
        HotelReviewViewModel CreateHotelReviewViewModel(HotelReview hotelReview);
    }
}