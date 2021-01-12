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
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public string AddHotel(Hotel hotel)
        {
            return _hotelRepository.AddHotel(hotel);
        }

        public List<JustHotel> GetHotels()
        {
            return _hotelRepository.GetHotels().Where(h => h.IsActive == "yes").OrderBy(h => h.Name).ToList();
        }
    }
}
