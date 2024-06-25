using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Room_Managing_API.Entities;
using RoomManaging.Common.Repositories;
using System.Security.Claims;

namespace Room_Managing_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoomManagingController : ControllerBase
    {
        private readonly IRoomManagingRepository _repository;

        public RoomManagingController(IRoomManagingRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Hotel,Guest")]
        [ProducesResponseType(typeof(IEnumerable<Hotel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotels = await _repository.GetHotels();
            return Ok(hotels);
        }

        [Authorize(Roles = "Hotel")]
        [HttpGet("{id}", Name = "GetHotel")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hotel>> GetHotelById(string id)
        {
            var hotel = await _repository.GetHotelById(id);
            return hotel == null ? NotFound(null) : Ok(hotel);
        }

        [Authorize(Roles = "Hotel,Guest")]
        [Route("[action]/{hotelId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Room>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsInHotel(string hotelId)
        {
            var rooms = await _repository.GetRoomsInHotel(hotelId);
            return Ok(rooms);
        }

        [Authorize(Roles = "Hotel")]
        [Route("[action]/{hotelId}/{roomId}")]
        [HttpGet]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Room), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Room>> GetRoomById(string hotelId, string roomId)
        {
            var room = await _repository.GetRoomById(hotelId, roomId);
            return room == null ? NotFound(null) : Ok(room);
        }

        [Authorize(Roles = "Hotel")]
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        public async Task<ActionResult<string>> CreateHotel([FromBody] Hotel hotel)
        {
            Console.WriteLine(hotel);
            await _repository.CreateHotel(hotel);

            return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
        }

        [Authorize(Roles = "Hotel")]
        [HttpPut]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        public async Task<ActionResult<Hotel>> UpdateHotel([FromBody] Hotel hotel)
        {
            return Ok(await _repository.UpdateHotel(hotel));
        }

        [Authorize(Roles = "Hotel")]
        [HttpDelete("DeleteHotel")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteHotel(string id)
        {
            await _repository.DeleteHotel(id);
            return Ok();
        }

        [Authorize(Roles = "Hotel")]
        [Route("[action]")]
        [HttpPut]
        [ProducesResponseType(typeof(Room),  StatusCodes.Status200OK)]
        public async Task<ActionResult<Room>> UpdateRoom([FromBody] Room room)
        {
            return Ok(await _repository.UpdateRoom(room));
        }
    }
}
