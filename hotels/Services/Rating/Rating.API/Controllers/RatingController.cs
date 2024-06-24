using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rating.Application.Features.Ratings.Commands.CreateRatingProcess;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Application.Features.Ratings.Commands.DeleteRating;
using Rating.Application.Features.Ratings.Queries.GetHotelRatingsQuery;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Application.Features.Ratings.Queries.GetAverageRatingQuery;
using Rating.Application.Features.Ratings.Queries.GetPendingRatingsQuery;
using Rating.Domain.Entities;

namespace Rating_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("pendingRatings/{guestId}")]
        [Authorize(Roles = "Guest")]
        [ProducesResponseType(typeof(IEnumerable<HotelReviewViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HotelReviewViewModel>>> GetPendingRatings(string guestId)
        {
            var query = new GetPendingRatingsQuery(guestId);
            var ratings = await _mediator.Send(query);
            return Ok(ratings);
        }

        [HttpGet("reviews/{hotelId}")]
        [Authorize(Roles = "Guest")]
        [ProducesResponseType(typeof(IEnumerable<HotelReviewViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HotelReviewViewModel>>> GetHotelReviews(string hotelId)
        {
            var query = new GetHotelRatingsQuery(hotelId);
            var ratings = await _mediator.Send(query);
            return Ok(ratings);
        }

        [HttpGet("rating/{hotelId}")]
        [Authorize(Roles = "Guest")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> GetAverageRating(string hotelId)
        {
            var query = new GetAverageRatingQuery(hotelId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Guest")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddReviewToCollection([FromBody] CreateReviewCommand hotelReview)
        {
            var ratings = await _mediator.Send(hotelReview);
            if (ratings)
                return Ok();
            return NotFound();
        }

        [HttpDelete]
        [Authorize(Roles = "Hotel")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHotelReview(string hotelId)
        {
            var deleteCommand = new DeleteRatingCommand(hotelId);
            var res = await _mediator.Send(deleteCommand);
            if (res)
                return Ok();
            return NotFound();

        }
    }
}