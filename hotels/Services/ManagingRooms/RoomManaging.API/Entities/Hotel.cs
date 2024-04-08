namespace Room_Managing_API.Entities

    
{
    public class Hotel
    {
        public string ID { get; set; }

        public IEnumerable<Room> Rooms { get; set; } = new List<Room>();

       
    }
}
