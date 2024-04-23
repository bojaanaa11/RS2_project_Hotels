using Grpc.Core;
using RoomManaging.GRPC;
using RoomManaging.GRPC.Protos;

namespace RoomManaging.GRPC.Services
{
    public class HotelsRoomsService : HotelsRoomsProtoService.HotelsRoomsProtoServiceBase
    {
        public override Task<GetAllHotelsResponse> GetAllHotels(GetAllHotelsRequest request, ServerCallContext context)
        {
            return base.GetAllHotels(request, context);
        }

        public override Task<GetAllRoomsResponse> GetAllRooms(GetAllRoomsRequest request, ServerCallContext context)
        {
            return base.GetAllRooms(request, context);
        }
    }
}
