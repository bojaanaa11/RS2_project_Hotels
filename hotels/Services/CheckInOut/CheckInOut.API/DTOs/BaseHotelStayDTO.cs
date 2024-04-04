namespace CheckInOut.API.DTOs;

public class BaseHotelStayDTO
{
    public string GuestName { get; set; }
    
    public int RoomNumber { get; set; }
    
    public DateTime CheckInDate { get; set; }

    public DateTime? CheckOutDate { get; set; }
}