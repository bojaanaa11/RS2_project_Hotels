using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CheckInOut.API.Exceptions;


namespace CheckInOut.API.Entities
{
    public class HotelStay
    {
        public string ReservationId {get; set;}
        public string GuestId {get; set;}
        public string RoomId {get; set;}
        
        public string StartDateTime {get; set;}
        public string? EndDateTime {get; private set;}

        public HotelStay()
        {
            
        }

        public HotelStay(string reservationId, string guestId, string roomId, string startDateTime, string? endDateTime=null)
        {
            ReservationId = reservationId ?? throw new ArgumentNullException(nameof(reservationId));
            GuestId = guestId ?? throw new ArgumentNullException(nameof(guestId));
            RoomId = roomId ?? throw new ArgumentNullException(nameof(roomId));
            StartDateTime = startDateTime ?? throw new ArgumentNullException(nameof(startDateTime));
            SetEndDateTime(endDateTime);
        }

        private void SetEndDateTime(string? setEndDateTime){
            if(setEndDateTime is null){
                EndDateTime = null;
                return;
            }
            string format = "dd/MM/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;

            DateTime dateStart = DateTime.ParseExact(StartDateTime, format, provider);
            DateTime dateEnd = DateTime.ParseExact(setEndDateTime, format, provider);
            if (dateEnd < dateStart)
            {
                throw new DateException("Check out date must be after check in date");
            }

            EndDateTime = setEndDateTime;
        }

    }
}