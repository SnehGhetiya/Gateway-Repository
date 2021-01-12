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
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<JustBooking> GetBookings()
        {
            return _bookingRepository.GetBookings();
        } 

        public string BookRoom(Booking booking)
        {
            return _bookingRepository.BookRoom(booking);
        }

        public string DeleteBooking(int id)
        {
            return _bookingRepository.DeleteBooking(id);
        }

        public string UpdateBookingDate(int id, Booking booking)
        {
            return _bookingRepository.UpdateBookingDate(id, booking);
        }

        public string UpdateBookingStatus(int id, Booking booking)
        {
            return _bookingRepository.UpdateBookingStatus(id, booking);
        }

        public bool IsRoomAvailable(string Date)
        {
            return _bookingRepository.IsRoomAvailable(Date);
        }
    }
}
