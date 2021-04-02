using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace hotelbookingAPI.Controllers
{
    public class HotelController : ApiController
    {
        [HttpGet]
        public IEnumerable<hotel> getHotels()
        {
            using (Database1Entities1 context = new Database1Entities1())
            {
                return context.hotels.ToList();
            }

        }

        

        [HttpPost]
        public IHttpActionResult addHotel(hotel h)
        {
            using (Database1Entities1 context = new Database1Entities1())
            {
                context.hotels.Add(h);
                context.SaveChanges();
                
            }
            return Ok();
        }
    }
}
