using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Database.HotelManagementEntities _dbContext;
        public RoomRepository()
        {
            _dbContext = new Database.HotelManagementEntities();
        }

        public string AddRoom(Room room)
        {
            try
            {
                if(room != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Room, Database.Room>();
                    });
                    IMapper mapper = config.CreateMapper();
                    var roomToAdd = mapper.Map<Room, Database.Room>(room);
                    _dbContext.Rooms.Add(roomToAdd);
                    _dbContext.SaveChanges();
                    return "Room added successfully.";
                }
                return "Model is null";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public List<JustRoom> GetRooms()
        {
            var entities = _dbContext.Rooms.OrderBy(r => r.Price);
            List<JustRoom> roomOfHotels = new List<JustRoom>();
            if(entities != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Room, JustRoom>();
                });
                IMapper mapper = config.CreateMapper();
                foreach(var item in entities)
                {
                    JustRoom room = mapper.Map<Database.Room, JustRoom>(item);
                    roomOfHotels.Add(room);
                }
                return roomOfHotels;
            }
            return null;
        }

        public List<JustRoom> GetRoomsByCategory(string category)
        {
            var entities = _dbContext.Rooms.Where(r => r.Category.Equals(category)).ToList();
            List<JustRoom> list = new List<JustRoom>();
            if(entities != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Room, JustRoom>();
                });
                IMapper mapper = config.CreateMapper();
                foreach(var item in entities)
                {
                    JustRoom room = mapper.Map<Database.Room, JustRoom>(item);
                    list.Add(room);
                }
                return list;
            }
            return null;
        }

        public List<JustRoom> GetRoomsByCity(string city)
        {
            var entities = _dbContext.Rooms.Where(h => h.Hotel.City.Equals(city)).ToList();
            List<JustRoom> list = new List<JustRoom>();
            if (entities != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Room, JustRoom>();
                });
                IMapper mapper = config.CreateMapper();
                foreach (var item in entities)
                {
                    JustRoom room = mapper.Map<Database.Room, JustRoom>(item);
                    list.Add(room);
                }
                return list;
            }
            return null;
        }

        public List<JustRoom> GetRoomsByPincode(string pincode)
        {
            var entities = _dbContext.Rooms.Where(h => h.Hotel.Pincode.Equals(pincode)).ToList();
            List<JustRoom> list = new List<JustRoom>();
            if (entities != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Room, JustRoom>();
                });
                IMapper mapper = config.CreateMapper();
                foreach (var item in entities)
                {
                    JustRoom room = mapper.Map<Database.Room, JustRoom>(item);
                    list.Add(room);
                }
                return list;
            }
            return null;
        }
    }
}
