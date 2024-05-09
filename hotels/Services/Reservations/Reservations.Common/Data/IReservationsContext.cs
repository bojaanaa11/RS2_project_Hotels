using MongoDB.Driver;
using Reservations.Common.Entities;

namespace Reservations.Common.Data
{
    public interface IReservationsContext
    {
        IMongoCollection<Reservation> Reservations { get; }
    }
}
