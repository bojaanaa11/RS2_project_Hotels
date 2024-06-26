﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Room_Managing_API.Entities;

namespace RoomManaging.Common.Repositories
{
    public class RoomManagingRepository : IRoomManagingRepository
    {
        private readonly IDistributedCache _cache;
        private readonly string ListOfAllHotels = "#listofallhotels#";

        public RoomManagingRepository(IDistributedCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotels = await _cache.GetStringAsync(ListOfAllHotels);
            if (string.IsNullOrEmpty(hotels))
            {
                return null;
            }
            IEnumerable<Hotel> allHotels = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(hotels);
            return allHotels;
        }

        public async Task<Hotel> GetHotelById(string id)
        {
            var hotel = await _cache.GetStringAsync(id);
            
            if (string.IsNullOrEmpty(hotel))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Hotel>(hotel); 
        }

        public async Task<IEnumerable<Room>> GetRoomsInHotel(string hotelId)
        {
            Hotel hotel = await GetHotelById(hotelId);
            return hotel.Rooms;
        }

        public async Task<Room> GetRoomById(string hotelId, string roomId)
        {
            Hotel hotel = await GetHotelById(hotelId);
            var room = hotel.Rooms.ToList().Find(r => r.Id == roomId);
            if (room == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Room>(room.Id);
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

        public async Task<int> CreateHotel(Hotel hotel)
        { 
            Hotel existingHotel = await GetHotelById(hotel.Id);
            if (existingHotel == null)
            {
                IEnumerable<Room> roomsInHotel = hotel.Rooms;
                Dictionary<string, int> existingRooms = new Dictionary<string, int>();
                foreach (Room room in roomsInHotel)
                {
                    if (existingRooms.ContainsKey(room.Id))
                    {
                        return 1;
                    }
                    existingRooms.Add(room.Id, 1);
                }
                
                var hotelString = JsonConvert.SerializeObject(hotel);
                await _cache.SetStringAsync(hotel.Id, hotelString);

                var list = await _cache.GetStringAsync(ListOfAllHotels);
                if (string.IsNullOrEmpty(list))
                {
                    IEnumerable<Hotel> hotels = new List<Hotel>();
                    hotels = hotels.Append(hotel);
                    var hotelsString = JsonConvert.SerializeObject(hotels);
                    await _cache.SetStringAsync(ListOfAllHotels, hotelsString);
                }

                IEnumerable<Hotel> allHotels = JsonConvert.DeserializeObject<List<Hotel>>(list);
                allHotels = allHotels.Append(hotel);
                var allHotelsString = JsonConvert.SerializeObject(allHotels);
                await _cache.SetStringAsync(ListOfAllHotels, allHotelsString);
            }
            else
            {
                return 2;
            }

            return 0;
            
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

            var list = await _cache.GetStringAsync(ListOfAllHotels);
            IEnumerable<Hotel> allHotels = JsonConvert.DeserializeObject<List<Hotel>>(list);

            var hasHotel = allHotels.ToList().Find(h => h.Id == hotel.Id);
            if (hasHotel == null)
            {
                return null;
            }
            allHotels = allHotels.Where(h => h.Id != hotel.Id).ToList();
            allHotels = allHotels.Append(hotel);

            var allHotelsString = JsonConvert.SerializeObject(allHotels);
            await _cache.SetStringAsync(ListOfAllHotels, allHotelsString);

            return await GetHotelById(hotel.Id);
        }

        public async Task DeleteHotel(string id)
        {
            Hotel hotel = await GetHotelById(id);
            await _cache.RemoveAsync(id);

            var list = await _cache.GetStringAsync(ListOfAllHotels);
            IEnumerable<Hotel> allHotels = JsonConvert.DeserializeObject<List<Hotel>>(list);
            allHotels = allHotels.Where(h => h.Id != id).ToList();

            var allHotelsString = JsonConvert.SerializeObject(allHotels);
            await _cache.SetStringAsync(ListOfAllHotels, allHotelsString);
        }
    }
}
