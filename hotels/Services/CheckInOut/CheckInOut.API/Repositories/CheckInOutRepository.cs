using System;
using System.Collections.Generic;
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

        async Task<bool> ICheckInOutRepository.CreateCheckInOut(HotelStayDTO StayDTO)
        {
            using var connection = _context.GetConnection();

            var stay=_mapper.Map<HotelStay>(StayDTO);
            if(stay is null)
                return false;

            var affected = await connection.ExecuteAsync(
            "INSERT INTO HotelStay (ReservationId,GuestName,RoomNumber,CheckInDate,CheckOutDate) VALUES (@ReservationId,@GuestName,@RoomNumber,@CheckInDate,@CheckOutDate)",
            new { ReservationId = stay.ReservationId,GuestName=stay.GuestName,RoomNumber=stay.RoomNumber,CheckInDate=stay.CheckInDate,CheckOutDate=stay.CheckOutDate});
            _logger.LogInformation(affected+" "+stay.GuestName);
            return affected != 0;
        }

        async Task<bool> ICheckInOutRepository.DeleteCheckInOut(int ReservationId)
        {
            using var connection = _context.GetConnection();

            var affected=await connection.ExecuteAsync("DELETE FROM HotelStay WHERE ReservationId=@id",
                new {id=ReservationId});
            _logger.LogInformation(affected.ToString());

            return affected!=0;
        }

        async Task<IEnumerable<HotelStayDTO>?> ICheckInOutRepository.GetCheckInOut(string GuestName)
        {
            using var connection = _context.GetConnection();

            var Stay =await connection.QueryAsync<HotelStay>("SELECT * FROM HotelStay WHERE GuestName = @name",
                new { name = GuestName });
        
            var StayDTO=_mapper.Map<IEnumerable<HotelStayDTO>?>(Stay);
            return StayDTO;
        }

        async Task<bool> ICheckInOutRepository.SetCheckOutDate(int ReservationId,DateTime CheckOutDate)
        {
            using var connection = _context.GetConnection();
            var affected=await connection.ExecuteAsync("UPDATE HotelStay SET CheckOutDate=@date WHERE ReservationId=@id AND CheckInDate < @date",
                new {id=ReservationId,date=CheckOutDate});
            _logger.LogInformation(affected.ToString());

            return affected!=0;
        }

        async Task<bool> ICheckInOutRepository.UpdateCheckInOut(HotelStayDTO Stay)
        {
            using var connection = _context.GetConnection();
            var affected=await connection.ExecuteAsync("UPDATE HotelStay SET GuestName=@name, RoomNumber=@room, CheckInDate=@datein, CheckOutDate=@dateout WHERE ReservationId=@id",
                new {id=Stay.ReservationId, name=Stay.GuestName, room=Stay.RoomNumber ,datein=Stay.CheckInDate,dateout=Stay.CheckOutDate});
            _logger.LogInformation(affected.ToString());

            return affected!=0;
        }
    }
}