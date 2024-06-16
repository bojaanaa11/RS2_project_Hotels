using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservations.Common.Entities;
using Reservations.Common.Repositories;

namespace Reservations.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReservationsController : ControllerBase
    {
        IReservationRepository _repository;

        public ReservationsController(IReservationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [Authorize(Roles = "Hotel")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Reservation>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await _repository.GetReservations();
            return Ok(reservations);
        }

        [Authorize(Roles = "Hotel,Guest")]
        [HttpGet("{id}", Name = "GetReservation")]
        [ProducesResponseType(typeof(Reservation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Reservation), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservationById(string id)
        {
            var reservation = await _repository.GetReservationById(id);
            return reservation == null ? NotFound(null) : Ok(reservation);
        }

        [Authorize(Roles = "Hotel,Guest")]
        [HttpPost]
        [ProducesResponseType(typeof(Reservation), StatusCodes.Status201Created)]
        public async Task<ActionResult<Reservation>> CreateReservation([FromBody] Reservation reservation)
        {
            await _repository.CreateReservation(reservation);
            return CreatedAtRoute("GetReservation", new { id = reservation.Id }, reservation);
        }

        [Authorize(Roles = "Hotel")]
        [HttpDelete("[action]")]
        [ProducesResponseType(typeof(Reservation), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteReservation()
        {
            return Ok(await _repository.Delete());
        }

        [Authorize(Roles = "Hotel,Guest")]
        [HttpDelete("{id}", Name = "DeleteReservation")]
        [ProducesResponseType(typeof(Reservation), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteReservationById(string id)
        {
            return Ok(await _repository.DeleteReservation(id));
        }
    }
}
