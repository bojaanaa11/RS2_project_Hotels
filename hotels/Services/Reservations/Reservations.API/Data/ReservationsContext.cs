using MongoDB.Driver;
using Reservations_API.Entities;

namespace Reservations_API.Data
{
    public class ReservationsContext : IReservationsContext
    {
        public ReservationsContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ReservationsDB");

            Reservations = database.GetCollection<Reservation>("Reservations");
            ReservationsContextSeed.SeedData(Reservations);
        }
        public IMongoCollection<Reservation> Reservations { get; }
    }
}
