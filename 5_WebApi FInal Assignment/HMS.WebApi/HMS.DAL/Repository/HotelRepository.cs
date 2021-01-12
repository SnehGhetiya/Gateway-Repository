using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.HotelManagementEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.HotelManagementEntities();
        }

        public string AddHotel(Hotel hotel)
        {
            try
            {
                if(hotel != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Hotel, Database.Hotel>();
                    });
                    IMapper mapper = config.CreateMapper();
                    var hotelToAdd = mapper.Map<Hotel, Database.Hotel>(hotel);
                    _dbContext.Hotels.Add(hotelToAdd);
                    _dbContext.SaveChanges();
                    return "Hotel added successfully";
                }
                return "Model is null";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public List<JustHotel> GetHotels()
        {
            var entites = _dbContext.Hotels.OrderBy(h => h.Name).ToList();
            List<JustHotel> hotelList = new List<JustHotel>();
            if(entites != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Hotel, JustHotel>();
                });
                IMapper mapper = config.CreateMapper();
                foreach (var item in entites)
                {
                    JustHotel hotel = mapper.Map<Database.Hotel, JustHotel>(item);
                    hotelList.Add(hotel);
                }
                return hotelList;
            }
            return null;
        }
    }
}
