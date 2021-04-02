using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hotelbookingAPI.Controllers
{
    public class HotelUserController : ApiController
    {
        [HttpGet]
        public Boolean checkUser(string email,string password)
        {
            using (Database1Entities1 context = new Database1Entities1())
            {
                hoteluser h = context.hotelusers.FirstOrDefault(e => e.email == email && e.password == password);
                if (h != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [HttpPost]
        public IHttpActionResult addUser(hoteluser u)
        {
            using (Database1Entities1 context = new Database1Entities1())
            {
                context.hotelusers.Add(u);
                context.SaveChanges();

            }
            return Ok();
        }
    }
}
