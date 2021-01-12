using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IRoomRepository
    {
        List<JustRoom> GetRooms();
        string AddRoom(Room room);
        List<JustRoom> GetRoomsByCity(string city);
        List<JustRoom> GetRoomsByPincode(string pincode);
        List<JustRoom> GetRoomsByCategory(string category);
    }
}
