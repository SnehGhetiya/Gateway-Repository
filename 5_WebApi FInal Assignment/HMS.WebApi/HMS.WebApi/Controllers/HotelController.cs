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
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        public IHttpActionResult GetHotelDetails()
        {
            return Ok(_hotelManager.GetHotels());
        }

        [HttpPost]
        public HttpResponseMessage PostNewHotel([FromBody]Hotel hotel)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _hotelManager.AddHotel(hotel));
        }
    }
}
