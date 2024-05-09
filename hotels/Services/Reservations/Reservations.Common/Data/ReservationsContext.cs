using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Reservations.Common.Entities;

namespace Reservations.Common.Data
{
    public class ReservationsContext : IReservationsContext
    {
        public IMongoCollection<Reservation> Reservations { get; }
        public ReservationsContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionSettings"));
            var database = client.GetDatabase("ReservationsDB");

            Reservations = database.GetCollection<Reservation>("Reservations");
            ReservationsContextSeed.SeedData(Reservations);
        }
    }
}
