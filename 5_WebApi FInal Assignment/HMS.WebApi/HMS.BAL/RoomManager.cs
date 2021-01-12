using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public string AddRoom(Room room)
        {
            return _roomRepository.AddRoom(room);
        }

        public List<JustRoom> GetRooms()
        {
            return _roomRepository.GetRooms();
        }

        public List<JustRoom> GetRoomsByCategory(string category)
        {
            return _roomRepository.GetRoomsByCategory(category);
        }

        public List<JustRoom> GetRoomsByCity(string city)
        {
            return _roomRepository.GetRoomsByCity(city);
        }

        public List<JustRoom> GetRoomsByPincode(string pincode)
        {
            return _roomRepository.GetRoomsByPincode(pincode);
        }
    }
}
