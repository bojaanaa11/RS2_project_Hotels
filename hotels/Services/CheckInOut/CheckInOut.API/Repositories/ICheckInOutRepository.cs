using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckInOut.API.DTOs;
using CheckInOut.API.Entities;

namespace CheckInOut.API.Repositories
{
    public interface ICheckInOutRepository
    {
        public Task<IEnumerable<HotelStayDTO>?> GetCheckInOutByGuest(string guestId);
        public Task<HotelStayDTO?> GetCheckInOutByReservation(string reservationId);
        public Task<bool> CreateCheckInOut(HotelStayDTO stay);
        public Task<bool> UpdateCheckInOut(HotelStayDTO stay);
        public Task<HotelStayDTO?> SetCheckOutDate(string reservationId,string endDateTime);
        public Task<bool> DeleteCheckInOut(string reservationId);
    }
}