using MongoDB.Driver;
using Reservations.API.Entities;

namespace Reservations.API.Data
{
    public class ReservationsContext : IReservationsContext
    {
        public IMongoCollection<Reservation> Reservations { get; }
        public ReservationsContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ReservationsDB");

            Reservations = database.GetCollection<Reservation>("Reservations");
            ReservationsContextSeed.SeedData(Reservations);
        }
    }
}
