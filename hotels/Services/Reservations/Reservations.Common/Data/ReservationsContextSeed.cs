using MongoDB.Driver;
using Reservations.Common.Entities;

namespace Reservations.Common.Data
{
    public class ReservationsContextSeed
    {
        public static void SeedData(IMongoCollection<Reservation> reservationsCollection)
        {
            var reservations_exist = reservationsCollection.Find(r => true).Any();
            if(!reservations_exist)
            {
                reservationsCollection.InsertManyAsync(GetPreconfiguredReservations());
            }
        }

        private static IEnumerable<Reservation> GetPreconfiguredReservations()
        {
            return new List<Reservation>()
            {
                new Reservation()
                {
                    Id = "1CD87E5FADA714BB541B9375",
                    UserId = "1",
                    HotelId = "1",
                    HotelName = "hotel1",
                    RoomId = "1",
                    BookingDateTime = "21/01/2022 21:00",
                    StartDateTime = "23/02/2022 07:00",
                    EndDateTime = "27/02/2022 12:00",
                    Status = "Confirmed"
                },
                new Reservation()
                {
                    Id = "F49F0FFA07D06EB6F248A883",
                    UserId = "2",
                    HotelId = "1",
                    HotelName = "hotel1",
                    RoomId = "2",
                    BookingDateTime = "21/01/2022 21:00",
                    StartDateTime = "23/02/2022 07:00",
                    EndDateTime = "27/02/2022 12:00",
                    Status = "Pending"
                },
                new Reservation()
                {
                    Id = "58D15865E2E9F01C684F9D99",
                    UserId = "2",
                    HotelId = "2",
                    HotelName = "hotel2",
                    RoomId = "2",
                    BookingDateTime = "21/01/2022 21:00",
                    StartDateTime = "23/02/2022 07:00",
                    EndDateTime = "27/02/2022 12:00",
                    Status = "Canceled"
                }
            };
        }
    }
}
