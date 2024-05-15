namespace Room_Managing_API.Entities

    
{
    public class Hotel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<string> FileImages { get; set; } = new List<string>();

        public IEnumerable<Room> Rooms { get; set; } = new List<Room>();

        public Hotel()
        {
        }

        public Hotel(string id)
        {
            Id = id;
        }
    }
}
