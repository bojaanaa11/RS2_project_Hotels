using Reservations.Common.Entities;

namespace Reservations.Common.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservations();

        Task<IEnumerable<Reservation>> GetReservationsByUserId(string userid);

        Task<Reservation> GetReservationById(string id);

        Task CreateReservation(Reservation reservation);

        Task<bool> DeleteReservation(string id);
    }
}
