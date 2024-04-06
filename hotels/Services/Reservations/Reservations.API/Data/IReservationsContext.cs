using MongoDB.Driver;
using Reservations.API.Entities;

namespace Reservations.API.Data
{
    public interface IReservationsContext
    {
        IMongoCollection<Reservation> Reservations { get; }
    }
}
