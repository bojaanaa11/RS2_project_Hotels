using MongoDB.Driver;
using Reservations_API.Entities;

namespace Reservations_API.Data
{
    public interface IReservationsContext
    {
        IMongoCollection<Reservation> Reservations { get; }
    }
}
