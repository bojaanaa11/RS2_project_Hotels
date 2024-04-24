using RoomManaging.GRPC.Protos;

namespace Reservations.API.GrpcServices
{
    public class HotelsRoomsGrpcService
    {
        private readonly HotelsRoomsProtoService.HotelsRoomsProtoServiceClient _hotelsroomsProtoServiceClient;

        public HotelsRoomsGrpcService(HotelsRoomsProtoService.HotelsRoomsProtoServiceClient hotelsroomsProtoServiceClient)
        {
            _hotelsroomsProtoServiceClient = hotelsroomsProtoServiceClient ?? throw new ArgumentNullException(nameof(hotelsroomsProtoServiceClient));
        }

        public async Task<GetAllHotelsResponse> GetAllHotels()
        {
            var hotelsRequest = new GetAllHotelsRequest();
            return await _hotelsroomsProtoServiceClient.GetAllHotelsAsync(hotelsRequest);
        }

        public async Task<GetAllRoomsResponse> GetAllRooms(string Id)
        {
            var roomsRequest = new GetAllRoomsRequest();
            roomsRequest.Id = Id;
            return await _hotelsroomsProtoServiceClient.GetAllRoomsAsync(roomsRequest);
        }
    }
}
