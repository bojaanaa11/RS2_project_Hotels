using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Room_Managing_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoomManaging.Common.Repositories
{
    public class RoomManagingRepository : IRoomManagingRepository
    {
        private readonly IDistributedCache _cache;

        public RoomManagingRepository(IDistributedCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        /*public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotel1 = await _cache.GetStringAsync("hotel_id_1");
            var hotel2 = await _cache.GetStringAsync("hotel_id_2");

            var hotels = JsonConvert
            return JsonConvert.DeserializeObject<IEnumerable<Hotel>>(hotel1);
        }*/

        public async Task<Hotel> GetHotelById(string id)
        {
            var hotel = await _cache.GetStringAsync(id);
            if (string.IsNullOrEmpty(hotel))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Hotel>(hotel); 
        }

        /*public async Task<IEnumerable<Room>> GetRoomsInHotel(string hotelId)
        {
            var room1 = await _cache.GetStringAsync("hotel_1_soba_1");
            var room2 = await _cache.GetStringAsync("hotel_1_soba_2");
            var room3 = await _cache.GetStringAsync("hotel_1_soba_3");
            var room4 = await _cache.GetStringAsync("hotel_2_soba_1");
            var room5 = await _cache.GetStringAsync("hotel_2_soba_2");
            throw new NotImplementedException();

        }*/

        public async Task<Room> GetRoomById(string hotelId, string roomId)
        {
            var room = await _cache.GetStringAsync(roomId);
            if (string.IsNullOrEmpty(room))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Room>(room);
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            var h = await _cache.GetStringAsync(room.HotelId);
            if (string.IsNullOrEmpty(h))
            {
                return null;
            }
            
            var hotel = JsonConvert.DeserializeObject<Hotel>(h);
            
            var hasRoom = hotel.Rooms.ToList().Find(r => r.HotelId == hotel.Id);
            if (hasRoom == null)
            {
                return null;
            }

            hasRoom.Status = room.Status;
            var hotelString = JsonConvert.SerializeObject(hotel);
            await _cache.SetStringAsync(hotel.Id, hotelString);
            return await GetRoomById(room.HotelId, room.Id);
        }

        public async Task CreateHotel(Hotel hotel)
        {
            var hotelString = JsonConvert.SerializeObject(hotel);
            await _cache.SetStringAsync(hotel.Id, hotelString);
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            var h = await _cache.GetStringAsync(hotel.Id);
            if (string.IsNullOrEmpty(h))
            {
                return null;
            }
            var hotelString = JsonConvert.SerializeObject(hotel);
            await _cache.SetStringAsync(hotel.Id, hotelString);

            return await GetHotelById(hotel.Id);
        }

        public async Task DeleteHotelById(string id)
        {
            await _cache.RemoveAsync(id);
        }
    }
}
