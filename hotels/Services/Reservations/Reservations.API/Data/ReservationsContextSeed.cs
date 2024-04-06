using MongoDB.Driver;
using Reservations_API.Entities;

namespace Reservations_API.Data
{
    public class ReservationsContextSeed
    {
        public static void SeedData(IMongoCollection<Reservation> reservationsCollection)
        {
            var empty = reservationsCollection.Find<Reservation>(res => true).Any<Reservation>();
            if(empty)
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
                    Id = "1",
                    UserId = "1",
                    RoomId = "1",
                    BookingDateTime = "21/01/2022 21:00",
                    StartDateTime = "23/02/2022 07:00",
                    EndDateTime = "27/02/2022 12:00",
                    Status = "Confirmed"
                },
                new Reservation()
                {
                    Id = "2",
                    UserId = "2",
                    RoomId = "2",
                    BookingDateTime = "21/01/2022 21:00",
                    StartDateTime = "23/02/2022 07:00",
                    EndDateTime = "27/02/2022 12:00",
                    Status = "Pending"
                },
                new Reservation()
                {
                    Id = "2",
                    UserId = "2",
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
