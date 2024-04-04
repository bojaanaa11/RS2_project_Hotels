using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CheckInOut.API.DTOs;
using CheckInOut.API.Entities;
using CheckInOut.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CheckInOut.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckInOutController : ControllerBase
    {
        private readonly ICheckInOutRepository _checkInOutRepository;
        private readonly IMapper _mapper;

        public CheckInOutController(ICheckInOutRepository checkInOutRepository, IMapper mapper)
        {
            _checkInOutRepository = checkInOutRepository ?? throw new ArgumentNullException(nameof(checkInOutRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet("HotelStayByGuestName")]
        [ProducesResponseType(typeof(IEnumerable<HotelStayDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<HotelStayDTO>>> GetHotelStay(string GuestName)
        {
            var stay = await _checkInOutRepository.GetCheckInOut(GuestName);
            if (stay is null)
                return NotFound();
            
            var stayDTO = _mapper.Map<IEnumerable<HotelStayDTO>>(stay);
            return Ok(stayDTO);
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateHotelStay([FromBody] HotelStayDTO Stay)
        {
            bool created = await _checkInOutRepository.CreateCheckInOut(Stay);

            if(created)
                return Created();
            else 
                return BadRequest();
        }

        [HttpDelete("DeleteHotelStay")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteHotelStay(int ReservationId)
        {
            bool deleted = await _checkInOutRepository.DeleteCheckInOut(ReservationId);

            if(deleted)
                return Ok();
            else 
                return BadRequest();
        }

        [HttpPut("CheckOutDate")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetCheckOutDate(int ReservationId, DateTime CheckOutDate)
        {
            bool updated = await _checkInOutRepository.SetCheckOutDate(ReservationId,CheckOutDate);

            if(updated)
                return Ok();
            else 
                return BadRequest();
        }
        [HttpPut("UpdateCheckInOut")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCheckInOut(HotelStayDTO Stay)
        {
            bool updated = await _checkInOutRepository.UpdateCheckInOut(Stay);

            if(updated)
                return Ok();
            else 
                return BadRequest();
        }
    }
}