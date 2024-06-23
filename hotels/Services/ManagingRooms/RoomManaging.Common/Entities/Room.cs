namespace Room_Managing_API.Entities
{
    public class Room
    {
        public string Id { get;  set; }

        public string HotelId { get; set; }

        public string RoomNumber { get; set; }

        public bool Status { get; set; }

        public double Price { get; set; }

        public List<string> FileImages { get; set; }

        public string Description { get; set; }

        public Room()
        {
            FileImages = [];
        }

    }
}
