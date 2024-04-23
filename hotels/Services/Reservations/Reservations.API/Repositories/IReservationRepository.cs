using Reservations.API.Entities;

namespace Reservations.API.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservations();

        Task<Reservation> GetReservationById(string id);

        Task CreateReservation(Reservation reservation);

        Task<bool> DeleteReservation(string id);
    }
}
