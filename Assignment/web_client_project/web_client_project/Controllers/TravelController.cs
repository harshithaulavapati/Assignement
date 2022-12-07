using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using web_client_project.Models;

namespace web_client_project.Controllers
{
    public class TravelController : Controller
    {
        // GET: Travel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            IEnumerable<Travel> travellist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44305/api/");
                var responsetask = webclient.GetAsync("Travel");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    travellist = JsonConvert.DeserializeObject<List<Travel>>(resultdata);
                }
                else
                {
                    travellist = Enumerable.Empty<Travel>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
                }
                return View(travellist);
            }
        }

        

        //public ActionResult Edit(decimal id)
        //{

        //    using (var webclient = new HttpClient())
        //    {
        //        webclient.BaseAddress = new Uri("https://localhost:44305/api/");
        //        var puttask = webclient.PutAsJsonAsync<Travel>("Travel"+id.ToString());
        //        puttask.Wait();
        //        var dataresult = puttask.Result;
        //        if (dataresult.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Display");
        //        }
        //    }
        //    ModelState.AddModelError(string.Empty, "Some Error Occured..");
        //    return View(id);
        //}

    }
}