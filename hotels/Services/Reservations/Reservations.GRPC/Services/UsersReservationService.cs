using AutoMapper;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Reservations.Common.Repositories;
using Reservations.GRPC.Protos;

namespace Reservations.GRPC.Services
{
    public class UsersReservationService : UsersReservationProtoService.UsersReservationProtoServiceBase
    {
        private readonly IReservationRepository _repository;
        private readonly ILogger<UsersReservationService> _logger;
        private readonly IMapper _mapper;

        public UsersReservationService(IReservationRepository repository, ILogger<UsersReservationService> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<GetReservationResponse> GetReservation(GetReservationRequest request, ServerCallContext context)
        {
            var reservations = await _repository.GetReservationsByUserId(request.UserId);

            var response = new GetReservationResponse();
            response.Reservations.AddRange(_mapper.Map<IEnumerable<GetReservationResponse.Types.Reservation>>(reservations));

            _logger.LogInformation("Sending reservations list for user {userid}.", request.UserId);

            return response;
        }
    }
}
