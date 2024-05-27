namespace CheckInOut.API.DTOs;

public class BaseHotelStayDTO
{
    public string GuestId { get; set; }
    
    public string RoomId { get; set; }
    
    public string StartDateTime { get; set; }

    public string? EndDateTime { get; set; }
}