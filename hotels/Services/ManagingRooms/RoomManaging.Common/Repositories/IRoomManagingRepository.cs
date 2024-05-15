using Room_Managing_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManaging.Common.Repositories
{
    public interface IRoomManagingRepository
    {
        //Task<IEnumerable<Hotel>> GetHotels();
        // dohvatanje hotela svih
        Task<Hotel> GetHotelById(string id);
        // dohvatanje hotela po id
        
        //Task<IEnumerable<Room>> GetRoomsInHotel(string hotelId);
        // dohvatanje svih soba iz hotela

        Task<Room> GetRoomById(string hotelId, string roomId);
            // get sobe po id

        Task CreateHotel(Hotel hotel);

        Task<Hotel> UpdateHotel(Hotel hotel);

        Task DeleteHotelById(string id);

        Task<Room> UpdateRoom(Room room);
            // update sobe - promena statusa
    }
}
