using HMS.BAL.Interface;
using HMS.Models;
using HMS.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HMS.WebApi.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    [UserAuthentiction]
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet]
        [Route("api/Booking/BookingsList")]
        public IHttpActionResult BookingsList()
        {
            return Ok(_bookingManager.GetBookings());
        }

        [HttpPost]
        [Route("api/Booking/NewBooking")]
        public HttpResponseMessage NewBooking([FromBody] Booking booking)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _bookingManager.BookRoom(booking));
        }

        [HttpPut]
        [Route("api/Booking/UpdateDate")]
        public HttpResponseMessage UpdateDate(int id, [FromBody] Booking booking)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _bookingManager.UpdateBookingDate(id, booking));
        }

        [HttpPut]
        [Route("api/Booking/UpdateStatus")]
        public HttpResponseMessage UpdateStatus(int id, [FromBody] Booking booking)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _bookingManager.UpdateBookingStatus(id, booking));
        }

        [Route("api/Booking/DeleteBooking")]
        public HttpResponseMessage DeleteBooking(int id)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _bookingManager.DeleteBooking(id));
        }

        [HttpGet]
        [Route("api/Booking/IsRoomAvailable")]
        public IHttpActionResult IsRoomAvailable(string date)
        {
            return Ok(_bookingManager.IsRoomAvailable(date));
        }
    }
}
