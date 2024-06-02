using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CheckInOut.API.DTOs;
using CheckInOut.API.Entities;
using CheckInOut.API.Repositories;
using Common.EventBus.Messages.Events;
using Grpc.Core;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Rating_API.GrpcService;
using Reservations.GRPC.Protos;

namespace CheckInOut.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckInOutController : ControllerBase
    {
        private readonly ICheckInOutRepository _checkInOutRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckInOutController> _logger;
        private readonly UsersReservationsGrpcService _usersReservation;
        private readonly IPublishEndpoint _publishEndpoint;

        public CheckInOutController(ICheckInOutRepository checkInOutRepository, IMapper mapper,ILogger<CheckInOutController> logger,UsersReservationsGrpcService usersReservation, IPublishEndpoint publishEndpoint)
        {
            _checkInOutRepository = checkInOutRepository ?? throw new ArgumentNullException(nameof(checkInOutRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _usersReservation = usersReservation ?? throw new ArgumentNullException((nameof(usersReservation)));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException((nameof(publishEndpoint)));
        }

        [HttpGet("HotelStayByGuestId")]
        [ProducesResponseType(typeof(IEnumerable<HotelStayDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<HotelStayDTO>>> GetHotelStay(string guestId)
        {
            var stay = await _checkInOutRepository.GetCheckInOutByGuest(guestId);
            if (stay is null)
                return NotFound();
            
            var stayDto = _mapper.Map<IEnumerable<HotelStayDTO>>(stay);
            return Ok(stayDto);
        }

        [HttpGet("GetUserReservations")]
        [ProducesResponseType(typeof(GetReservationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserReservations(string userId)
        {
            try
            {
                var reservations = await _usersReservation.GetReservation(userId);
                return Ok(reservations);
            }
            catch (RpcException e)
            {
                _logger.LogInformation("Error while retrieving reservations for guest {userId} : {message}",userId,  e.Message);
                return StatusCode(500, "An error occurred while retrieving reservations.");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateHotelStay(string userId, string reservationId)
        {
            GetReservationResponse reservations;
            try
            {
                reservations = await _usersReservation.GetReservation(userId);
                
            }
            catch (RpcException e)
            {
                _logger.LogInformation("Error while retrieving reservations for guest {userId} : {message}",userId,  e.Message);
                return StatusCode(500, "An error occurred while retrieving reservations.");
            }

            var reservation = reservations.Reservations.First(r => r.UserId == userId && r.Id==reservationId);

            var stay = new HotelStayDTO();
            stay.ReservationId = reservation.Id;
            stay.GuestId = reservation.UserId;
            stay.RoomId = reservation.RoomId;
            stay.HotelId = reservation.HotelId;
            stay.StartDateTime = reservation.StartDateTime;
            stay.EndDateTime = null;
            
            
            
            bool created = await _checkInOutRepository.CreateCheckInOut(stay);

            if (created)
            {
                _logger.LogInformation("Checking in successfull for this guest: "+stay.ReservationId+" "+stay.RoomId+" "+stay.StartDateTime);
                return Created();
            }
            else
            {
                _logger.LogInformation("Checking in not successfull for this guest: "+stay.ReservationId+" "+stay.RoomId+" "+stay.StartDateTime);
                return BadRequest();
            }
        }

        [HttpDelete("DeleteHotelStay")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteHotelStay(string reservationId)
        {
            var deleted = await _checkInOutRepository.DeleteCheckInOut(reservationId);

            if(deleted)
                return Ok();
            else 
                return BadRequest();
        }
        [HttpPut("CheckOutDate")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetCheckOutDate(string reservationId, String endDateTime)
        {
            var stay = await _checkInOutRepository.SetCheckOutDate(reservationId,endDateTime);

            if (stay == null) return BadRequest();
            var eventMessage = _mapper.Map<GuestCheckoutEvent>(stay);
            await _publishEndpoint.Publish(eventMessage);
            return Ok();
        }
        [HttpPut("UpdateCheckInOut")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCheckInOut(HotelStayDTO stay)
        {
            var updated = await _checkInOutRepository.UpdateCheckInOut(stay);

            if(updated)
                return Ok();
            else 
                return BadRequest();
        }
    }
}