namespace Common.EventBus.Messages.Events;

public class GuestCheckoutEvent : IntegrationBaseEvent
{
    public string ReservationId {get; set;}
    public string GuestId {get; set;}
    public string RoomId {get; set;}
        
    public string HotelId {get; set; }
        
    public string StartDateTime {get; set;}
    public string? EndDateTime {get; private set;}
}