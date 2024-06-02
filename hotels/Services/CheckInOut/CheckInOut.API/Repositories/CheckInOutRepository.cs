using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CheckInOut.API.Context;
using CheckInOut.API.DTOs;
using CheckInOut.API.Entities;
using Dapper;

namespace CheckInOut.API.Repositories
{
    public class CheckInOutRepository : ICheckInOutRepository
    {
        private readonly ICheckInOutContext _context;
        private readonly ILogger<ICheckInOutRepository> _logger;
        private readonly IMapper _mapper;

        public CheckInOutRepository(ICheckInOutContext context,ILogger<ICheckInOutRepository> logger, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<HotelStayDTO>?> GetCheckInOutByGuest(string guestId)
        {
            await using var connection = _context.GetConnection();

            var stay =await connection.QueryAsync<HotelStay>("SELECT ReservationId, GuestId,HotelId, RoomId, StartDateTime, EndDateTime FROM HotelStay WHERE GuestId = @name",
                new { name = guestId });
        
            var stayDto=_mapper.Map<IEnumerable<HotelStayDTO>?>(stay);
            return stayDto;
        }

        public async Task<HotelStayDTO?> GetCheckInOutByReservation(string reservationId)
        {
            await using var connection = _context.GetConnection();

            var stay =await connection.QueryFirstAsync<HotelStay>("SELECT ReservationId, GuestId,HotelId, RoomId, StartDateTime, EndDateTime FROM HotelStay WHERE ReservationId = @name",
                new { name = reservationId });
        
            var stayDto=_mapper.Map<HotelStayDTO?>(stay);
            return stayDto;
        }

        async Task<bool> ICheckInOutRepository.CreateCheckInOut(HotelStayDTO stayDto)
        {
            await using var connection = _context.GetConnection();

            var stay=_mapper.Map<HotelStay>(stayDto);
            if(stay is null)
                return false;

            var affected = await connection.ExecuteAsync(
            "INSERT INTO HotelStay (ReservationId,GuestId,HotelId,RoomId,StartDateTime,EndDateTime) VALUES (@ReservationId,@GuestName,@HotelId,@RoomNumber,@CheckInDate,@CheckOutDate)",
            new { ReservationId = stay.ReservationId,GuestName=stay.GuestId,HotelId=stay.HotelId,RoomNumber=stay.RoomId,CheckInDate=stay.StartDateTime,CheckOutDate=stay.EndDateTime});
            _logger.LogInformation(affected+" "+stay.GuestId);
            return affected != 0;
        }

        public async Task<HotelStayDTO?> SetCheckOutDate(string reservationId, string endDateTime)
        {
            await using var connection = _context.GetConnection();
            var affected=await connection.ExecuteAsync("UPDATE HotelStay SET EndDateTime=@date WHERE ReservationId=@id AND to_date(StartDateTime, 'DD/MM/YYYY') < to_date(@date, 'DD/MM/YYYY')",
                new {id=reservationId,date=endDateTime});
            _logger.LogInformation(affected.ToString());

            if (affected != 0)
            {
                return await GetCheckInOutByReservation(reservationId);
            }

            return null;
        }

        async Task<bool> ICheckInOutRepository.DeleteCheckInOut(string reservationId)
        {
            await using var connection = _context.GetConnection();

            var affected = await connection.ExecuteAsync("DELETE FROM HotelStay WHERE ReservationId=@id",
                new { id = reservationId });
            _logger.LogInformation(affected.ToString());

            return affected != 0;
        }

        async Task<bool> ICheckInOutRepository.UpdateCheckInOut(HotelStayDTO stay)
        {
            await using var connection = _context.GetConnection();
            var affected=await connection.ExecuteAsync("UPDATE HotelStay SET GuestId=@name, HotelId = @hotelId, RoomId=@room, StartDateTime=@datein WHERE ReservationId=@id",
                new {id=stay.ReservationId, name=stay.GuestId,hotelId=stay.HotelId, room=stay.RoomId ,datein=stay.StartDateTime,dateout=stay.EndDateTime});
            _logger.LogInformation(affected.ToString());

            return affected!=0;
        }
    }
}