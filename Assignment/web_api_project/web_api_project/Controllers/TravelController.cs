using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api_project.Models;

namespace web_api_project.Controllers
{
    public class TravelController : ApiController
    {
        EmployeetravelbookingsystemEntities et = new EmployeetravelbookingsystemEntities();
        public IEnumerable<TravelRequest> Get()
        {
            return et.TravelRequests.ToList();
        }
        [HttpPut]
        public IHttpActionResult putnewproduct(TravelRequest m)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validations Failed");
            }
            using (var c = new EmployeetravelbookingsystemEntities())
            {
                var oldmovie = c.TravelRequests.Where(o => o.Request_Id == m.Request_Id).FirstOrDefault<TravelRequest>();
                if (oldmovie != null)
                {
                    //oldmovie.Request_Id = m.Request_Id;
                    //oldmovie.Request_Date = m.Request_Date;
                    //oldmovie.From_Location = m.From_Location;
                    oldmovie.Current_Status = m.Current_Status;
                    c.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
    }
}
