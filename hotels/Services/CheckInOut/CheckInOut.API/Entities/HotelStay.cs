using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckInOut.API.Exceptions;

namespace CheckInOut.API.Entities
{
    public class HotelStay
    {
        public int ReservationId {get; set;}
        public string GuestName {get; set;}
        public int RoomNumber {get; set;}
        
        public DateTime CheckInDate {get; set;}
        public DateTime? CheckOutDate {get; private set;}

        public HotelStay(int reservationId, string guestName,int roomnumber, DateTime checkindate, DateTime? checkoutdate=null){
            ReservationId = reservationId;
            GuestName = guestName ?? throw new ArgumentNullException(nameof(guestName));
            RoomNumber = roomnumber;
            CheckInDate = checkindate;
            SetCheckOutDate(checkoutdate);
        }

        public void SetCheckOutDate(DateTime? checkoutdate){
            if(checkoutdate is null){
                CheckOutDate = null;
                return;
            }
            if(checkoutdate < CheckInDate){
                CheckOutDate = null;
                throw new DateException("Check out date must be after check in date");                 
            } else 
            CheckOutDate = checkoutdate;
        }

    }
}