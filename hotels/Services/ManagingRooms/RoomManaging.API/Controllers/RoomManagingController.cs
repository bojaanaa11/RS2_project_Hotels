using Microsoft.AspNetCore.Mvc;
using Room_Managing_API.Entities;
using RoomManaging.Common.Repositories;
using System.Security.Claims;

namespace Room_Managing_API.Controllers
{
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
        [ProducesResponseType(typeof(IEnumerable<Hotel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotels = await _repository.GetHotels();
            return Ok(hotels);
        }

        [HttpGet("{id}", Name = "GetHotel")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hotel>> GetHotelById(string id)
        {
            var hotel = await _repository.GetHotelById(id);
            return hotel == null ? NotFound(null) : Ok(hotel);
        }

        [Route("[action]/{hotelId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Room>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsInHotel(string hotelId)
        {
            var rooms = await _repository.GetRoomsInHotel(hotelId);
            return Ok(rooms);
        }

        [Route("[action]/{hotelId}/{roomId}")]
        [HttpGet]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Room), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Room>> GetRoomById(string hotelId, string roomId)
        {
            var room = await _repository.GetRoomById(hotelId, roomId);
            return room == null ? NotFound(null) : Ok(room);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            await _repository.CreateHotel(hotel);
            return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        public async Task<ActionResult<Hotel>> UpdateHotel([FromBody] Hotel hotel)
        {
            return Ok(await _repository.UpdateHotel(hotel));
        }

        [HttpDelete("DeleteHotel")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteHotel(Hotel hotel)
        {
            await _repository.DeleteHotel(hotel);
            return Ok();
        }

        [Route("[action]")]
        [HttpPut]
        [ProducesResponseType(typeof(Room),  StatusCodes.Status200OK)]
        public async Task<ActionResult<Room>> UpdateRoom([FromBody] Room room)
        {
            return Ok(await _repository.UpdateRoom(room));
        }
    }
}
