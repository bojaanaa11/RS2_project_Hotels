using AutoMapper;
using Grpc.Core;
using RoomManaging.Common.Repositories;
using RoomManaging.GRPC;
using RoomManaging.GRPC.Protos;

namespace RoomManaging.GRPC.Services
{
    public class HotelsRoomsService : HotelsRoomsProtoService.HotelsRoomsProtoServiceBase
    {
        private readonly IRoomManagingRepository _repository;
        private readonly ILogger<HotelsRoomsService> _logger;
        private readonly IMapper _mapper;

        public HotelsRoomsService(IRoomManagingRepository repository, ILogger<HotelsRoomsService> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<GetAllHotelsResponse> GetAllHotels(GetAllHotelsRequest request, ServerCallContext context)
        {
            var hotels = await _repository.GetHotels();
            
            var response = new GetAllHotelsResponse();
            response.Hotels.AddRange(_mapper.Map<IEnumerable<GetAllHotelsResponse.Types.Hotel>>(hotels));

            _logger.LogInformation("Sending list of all hotels");

            return response;
        }

        public override async Task<GetAllRoomsResponse> GetAllRooms(GetAllRoomsRequest request, ServerCallContext context)
        {
            var rooms = await _repository.GetRoomsInHotel(request.HotelId);

            var response = new GetAllRoomsResponse();
            response.Rooms.AddRange(_mapper.Map<IEnumerable<GetAllRoomsResponse.Types.Room>>(rooms));

            _logger.LogInformation("Sending list of all rooms for hotel: {hotelId}", request.HotelId);

            return response;
        }
    }
}
