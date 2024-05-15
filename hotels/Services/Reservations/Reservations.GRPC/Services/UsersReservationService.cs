using Grpc.Core;
using Reservations.Common.Repositories;
using Reservations.GRPC.Protos;

namespace Reservations.GRPC.Services
{
    public class UsersReservationService : UsersReservationProtoService.UsersReservationProtoServiceBase
    {
        private readonly IReservationRepository _repository;
        private readonly ILogger<UsersReservationService> _logger;

        public UsersReservationService(IReservationRepository repository, ILogger<UsersReservationService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        public override async Task<GetReservationResponse> GetReservation(GetReservationRequest request, ServerCallContext context)
        {
            var reservations = await _repository.GetReservationsByUserId(request.UserId);

            var response = new GetReservationResponse();
            response.Reservations.AddRange((IEnumerable<GetReservationResponse.Types.Reservation>)reservations);

            _logger.LogInformation("Sending reservations list for user {userid}.", request.UserId);

            return response;
        }
    }
}
