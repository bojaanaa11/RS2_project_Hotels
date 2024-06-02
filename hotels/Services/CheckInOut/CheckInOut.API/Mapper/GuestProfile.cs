using AutoMapper;
using Common.EventBus.Messages.Constants;

namespace CheckInOut.API.Mapper;

public class GuestProfile : Profile 
{
    public GuestProfile()
    {
        CreateMap<Entities.HotelStay, Common.EventBus.Messages.Events.GuestCheckoutEvent>().ReverseMap();
        CreateMap<DTOs.HotelStayDTO, Common.EventBus.Messages.Events.GuestCheckoutEvent>().ReverseMap();
    }
}