using Reservations.GRPC.Protos;

namespace Rating_API.GrpcService;

public class UsersReservationsGrpcService
{
    private readonly UsersReservationProtoService.UsersReservationProtoServiceClient _usersReservationClient;

    public UsersReservationsGrpcService(
        UsersReservationProtoService.UsersReservationProtoServiceClient usersReservationClient)
    {
        _usersReservationClient =
            usersReservationClient ?? throw new ArgumentNullException(nameof(usersReservationClient));
    }

    public async Task<GetReservationResponse> GetReservation(string userId)
    {
        var request = new GetReservationRequest();
        request.UserId = userId;

        return await _usersReservationClient.GetReservationAsync(request);
    }
}