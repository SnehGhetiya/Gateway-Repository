using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data.Entity;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Database.HotelManagementEntities _dbContext;
        public BookingRepository()
        {
            _dbContext = new Database.HotelManagementEntities();
        }

        public List<JustBooking> GetBookings()
        {
            var entites = _dbContext.Bookings.OrderBy(b => b.Room_Id).ToList();
            List<JustBooking> bookingsList = new List<JustBooking>();
            if (entites != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Booking, JustBooking>();
                });
                IMapper mapper = config.CreateMapper();
                foreach (var item in entites)
                {
                    JustBooking booking = mapper.Map<Database.Booking, JustBooking>(item);
                    bookingsList.Add(booking);
                }
                return bookingsList;
            }
            return null;
        }
        public string BookRoom(Booking booking)
        {
            try
            {
                if(booking != null)
                {
                    Database.Booking newBooking = new Database.Booking();
                    newBooking.Booking_Date = booking.Booking_Date;
                    newBooking.Room_Id = booking.Room_Id;
                    newBooking.Status = "Optional";
                    _dbContext.Bookings.Add(newBooking);
                    _dbContext.SaveChanges();
                    return "Room is booked";
                }
                return "Model is null";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBooking(int id)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(id);
                if(entity != null)
                {
                    _dbContext.Bookings.Remove(entity);
                    _dbContext.SaveChanges();
                    return "Booking deleted";
                }
                return "Model is null";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBookingDate(int id, Booking booking)
        {
            try
            {
                var bookingToUpdate = _dbContext.Bookings.Find(id);
                if (bookingToUpdate == null) return "Model is null";
                else
                {
                    bookingToUpdate.Booking_Date = booking.Booking_Date;
                    /*_dbContext.Entry(bookingToUpdate).State = EntityState.Modified;*/
                    _dbContext.SaveChanges();
                    return "Booking date has been updated.";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBookingStatus(int id, Booking booking)
        {
            try
            {
                var bookingToBeUpdate = _dbContext.Bookings.Find(id);
                if (bookingToBeUpdate == null) return "Model is null";
                else
                {
                    bookingToBeUpdate.Status = booking.Status;
                    /*_dbContext.Entry(booking).State = EntityState.Modified;*/
                    _dbContext.SaveChanges();
                    return "Booking status has been updated.";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public bool IsRoomAvailable(string Date)
        {
            var entities = _dbContext.Bookings.Where(b => b.Booking_Date == Date && b.Status == "Optional").ToList();
            if(entities.Count() < 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
