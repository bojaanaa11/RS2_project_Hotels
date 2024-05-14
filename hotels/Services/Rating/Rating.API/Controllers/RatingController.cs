using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rating.Application.Features.Ratings.Commands.CreateReview;
using Rating.Application.Features.Ratings.Queries.GetHotelRatingsQuery;
using Rating.Application.Features.Ratings.Queries.ViewModels;
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

        [HttpGet("{hotelname}")]
        [ProducesResponseType(typeof(IEnumerable<HotelReviewViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HotelReviewViewModel>>> GetHotelReviews(string hotelname)
        {
            var query = new GetHotelRatingsQuery(hotelname);
            var ratings = await _mediator.Send(query);
            return Ok(ratings);
        }
        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddReviewToCollection([FromBody]CreateReviewCommand hotelReview)
        {
            var ratings = await _mediator.Send(hotelReview);
            return Ok(ratings);
        }
    }
}