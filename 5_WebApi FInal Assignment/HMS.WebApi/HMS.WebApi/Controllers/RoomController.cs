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
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpGet]
        [Route("api/Room/GetRoomDetails/{city?}/{pincode?}/{category?}")]
        public IHttpActionResult GetRoomDetails(string city = null, string pincode = null, string category = null)
        {
            if (city != null)
            {
                if(_roomManager.GetRoomsByCity(city).Count() != 0)
                {
                    return Ok(_roomManager.GetRoomsByCity(city));
                }
                return NotFound();
            }
            else if(pincode != null)
            {
                if(_roomManager.GetRoomsByPincode(pincode).Count() != 0)
                {
                    return Ok(_roomManager.GetRoomsByPincode(pincode));
                }
                return NotFound();
            }
            else if(category != null)
            {
                if(_roomManager.GetRoomsByCategory(category).Count() != 0)
                {
                    return Ok(_roomManager.GetRoomsByCategory(category));
                }
            }
            return Ok(_roomManager.GetRooms());
        }

        [HttpPost]
        public HttpResponseMessage AddRoom(Room room)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _roomManager.AddRoom(room));
        }
    }
}
