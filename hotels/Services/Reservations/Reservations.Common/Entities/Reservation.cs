using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Reservations.Common.Entities
{
    public class Reservation
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }

        public string HotelId { get; set; }
        public string RoomId { get; set; }
        public string BookingDateTime { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string Status { get; set; }
    }
}
