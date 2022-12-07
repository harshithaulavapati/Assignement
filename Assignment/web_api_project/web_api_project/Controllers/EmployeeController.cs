using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api_project.Models;

namespace web_api_project.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeetravelbookingsystemEntities et = new EmployeetravelbookingsystemEntities();
        [HttpGet]
        public IEnumerable<TravelRequest> Get()
        {
            return et.TravelRequests.ToList();
        }

        //Post
        [HttpPost]
        public IHttpActionResult PostNewProduct([FromBody] TravelRequest p)
        {
            if (!ModelState.IsValid)
                return BadRequest("Validations Failed");
            et.TravelRequests.Add(new TravelRequest()
            {
                Request_Id = p.Request_Id,
                Request_Date = p.Request_Date,
                From_Location = p.From_Location,
                To_Location = p.To_Location,
                User_type_Id = p.User_type_Id,
                Current_Status = p.Current_Status
            });
            et.SaveChanges();
            return Ok(p);
        }
        [HttpPut]
        public IHttpActionResult putnewproduct(TravelRequest m)
        {
            TravelRequest tr = et.TravelRequests.Find(m.Request_Id);
            if(tr==null)
            {
                return NotFound();
            }
              m.Request_Id = m.Request_Id;
              m.Request_Date = m.Request_Date;
              m.From_Location = m.From_Location;
              et.Entry(m).State = System.Data.Entity.EntityState.Modified;
              et.SaveChanges();
            return Ok();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Validations Failed");
            //}
            //using (var c = new EmployeetravelbookingsystemEntities())
            //{
            //    var oldmovie = c.TravelRequests.Where(o => o.Request_Id == m.Request_Id).FirstOrDefault<TravelRequest>();
            //    if (oldmovie != null)
            //    {
            //        //oldmovie.Request_Id = m.Request_Id;
            //        oldmovie.Request_Date = m.Request_Date;
            //        oldmovie.From_Location = m.From_Location;
            //        c.SaveChanges();
            //    }
            //    else
            //    {
            //        return NotFound();
            //    }
            //}
            //return Ok();
        }
        [HttpDelete]
        // DELETE: api/ProductMasters/5
        // [ResponseType(typeof(ProductMaster))]
        //public IHttpActionResult deleteproduct(int id)
        //////{
        //////    TravelRequest productMaster = et.TravelRequests.Find(id);
        ////    if (productMaster == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    et.TravelRequests.Remove(productMaster);
        ////    et.SaveChanges();

        ////    return Ok(productMaster);
        public IHttpActionResult productDelete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var m = new EmployeetravelbookingsystemEntities())
            {
                var travelrequest = m.TravelRequests
                    .Where(c => c.Request_Id == id)
                    .FirstOrDefault();

                m.Entry(travelrequest).State = System.Data.Entity.EntityState.Deleted;
                m.SaveChanges();
            }

            return Ok();


        }        
       
    }
}
