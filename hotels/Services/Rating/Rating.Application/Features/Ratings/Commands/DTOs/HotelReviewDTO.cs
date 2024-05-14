using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.Entities;
using Rating.Domain.ValueObjects;

namespace Rating.Application.Features.Ratings.Commands.DTOs
{
    public class HotelReviewDTO
    {
        //hotel
        public int HotelId { get; set; }
        //guest
        public int GuestId { get; set; } 
        public string GuestName { get; set; } 
        public string EmailAddress { get; set; }
        public int ReservationId {  get; set;  } 
        //rating
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}