using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Contracts.Factories;
using Rating.Application.Features.Ratings.Commands.CreateRating;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;

namespace Rating.Infrastructure.Factories
{
    public class HotelRatingCollectionViewModelFactory(IHotelReviewViewModelFactory factory) : IHotelRatingCollectionViewModelFactory
    {
        private readonly IHotelReviewViewModelFactory _factory = factory ?? throw new ArgumentNullException(nameof(factory));

        public HotelRatingCollectionViewModel CreateHotelRatingCollectionViewModel(HotelRatingCollection ratings)
        {
            var viewModel = new HotelRatingCollectionViewModel
            {
                Id = ratings.Id,
                HotelId = ratings.HotelId,
                HotelName = ratings.HotelName
            };

            var reviewList = new List<HotelReviewViewModel>();

            foreach (var review in ratings.Reviews){
                var reviewViewModel = _factory.CreateHotelReviewViewModel(review);
                reviewList.Add(reviewViewModel);
            }

            viewModel.Reviews=reviewList;
            return viewModel;
                
        }
    }
}