using AutoMapper;
using Rating.Application.Features.Ratings.Commands.CreateRatingProcess;

namespace Rating_API.Mapper;

public class GuestProfile : Profile
{
    public GuestProfile()
    {
         CreateMap<Common.EventBus.Messages.Events.GuestCheckoutEvent, CreateRatingProcessCommand>()
            .ConstructUsing(src => new CreateRatingProcessCommand(src.HotelId, src.ReservationId, src.GuestId));
    }    
}
