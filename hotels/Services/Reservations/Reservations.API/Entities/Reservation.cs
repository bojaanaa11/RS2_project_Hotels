namespace Reservations_API.Entities
{
    public class Reservation
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public string BookingDateTime { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string Status { get; set; }
    }
}
