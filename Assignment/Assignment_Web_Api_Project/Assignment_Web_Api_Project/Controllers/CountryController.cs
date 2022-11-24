using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using Assignment_Web_Api_Project.Models;

namespace Assignment_Web_Api_Project.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
       
        static List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1,CountryName="Australia", Capital="Canberra"},
            new Country{Id=2,CountryName="Bangladesh", Capital="Dhaka"},
            new Country{Id=3,CountryName="Canada", Capital="Ottawa"},
        };
        
        [HttpGet]
        [Route("list")]
        public IEnumerable<Country> Get()
        {
            return countrylist;
        }
        //Get using HttpResponseMessage object
        [HttpGet]
        [Route("CountryHTTP")]
        public HttpResponseMessage GetCountryList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(10)
            };
            return response;
        }
        //implement IHttpActionResult to get users by id
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetByID(int cid)
        {
            var country = countrylist.Find(x => x.Id == cid);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        
        //posting
        [HttpPost]
        [Route("countrypost")]
        public List<Country> Posting([FromBody] Country cou)
        {
            countrylist.Add(cou);
            return countrylist;
        }


      [HttpPut]
      [Route("allcountries")]
        public IHttpActionResult putting(int mid, [FromBody] Country u)
        {
            var countries = countrylist.SingleOrDefault(x => x.Id == mid);
            if(countries!= null)
            {
                countrylist[mid - 1] = u;
                return Ok(countrylist);
            }
            else 
                return NotFound();

        }
        //put
        [HttpPut]
        public IEnumerable<Country> Putting(int id, [FromBody] Country u)
        {
            countrylist[id - 1] = u;
            return countrylist;
        }

        //delete
        [HttpDelete]
        public IEnumerable<Country> Delete(int id)
        {
            countrylist.RemoveAt(id - 1);
            return countrylist;
        }



    }

}
