using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IBookingRepository
    {
        List<JustBooking> GetBookings();
        string BookRoom(Booking booking);
        string UpdateBookingDate(int id, Booking booking);
        string UpdateBookingStatus(int id, Booking booking);
        string DeleteBooking(int id);
        bool IsRoomAvailable(string date);
    }
}
