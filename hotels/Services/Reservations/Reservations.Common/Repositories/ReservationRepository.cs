using MongoDB.Driver;
using Reservations.Common.Data;
using Reservations.Common.Entities;

namespace Reservations.Common.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IReservationsContext _context;

        public ReservationRepository(IReservationsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateReservation(Reservation reservation)
        {
            await _context.Reservations.InsertOneAsync(reservation);
        }

        public async Task<bool> DeleteReservation(string id)
        {
            var deleteResult = await _context.Reservations.DeleteOneAsync(r => (r.Id == id));
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Reservation> GetReservationById(string id)
        {
            return await _context.Reservations.Find(r => (r.Id == id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _context.Reservations.Find(r => true).ToListAsync();
        }
    }
}
