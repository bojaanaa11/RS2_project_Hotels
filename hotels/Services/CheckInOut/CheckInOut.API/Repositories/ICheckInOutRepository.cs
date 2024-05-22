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
        public Task<IEnumerable<HotelStayDTO>?> GetCheckInOut(string GuestId);
        public Task<bool> CreateCheckInOut(HotelStayDTO Stay);
        public Task<bool> UpdateCheckInOut(HotelStayDTO Stay);
        public Task<bool> SetCheckOutDate(string ReservationId,string EndDateTime);
        public Task<bool> DeleteCheckInOut(string ReservationId);
    }
}