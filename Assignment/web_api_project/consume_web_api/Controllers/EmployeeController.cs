using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using consume_web_api.Models;
using Newtonsoft.Json;


namespace consume_web_api.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            IEnumerable<EmployeeMvc> emplist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44305/api/");
                var responsetask = webclient.GetAsync("employee");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    emplist = JsonConvert.DeserializeObject<List<EmployeeMvc>>(resultdata);
                }
                else
                {
                    emplist = Enumerable.Empty<EmployeeMvc>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured.. Try Later");
                }
                return View(emplist);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // [Authorize]
        public ActionResult Create(EmployeeMvc mov)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44305/api/");
                var posttask = webclient.PostAsJsonAsync<EmployeeMvc>("employee", mov);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Display");
                }
            }
            ModelState.AddModelError(string.Empty, "Some Error Occured..");
            return View(mov);
        }
        [HttpGet]
        public ActionResult Edit(decimal id)
        {
            if (id == 0)
            {
                return View(new EmployeeMvc());
            }
            else
            {
                using (var webclient = new HttpClient())
                {
                    webclient.BaseAddress = new Uri("https://localhost:44305/api/");
                    HttpResponseMessage httpResponseMessage = webclient.GetAsync("employee/" + id.ToString()).Result;
                    return View(httpResponseMessage.Content.ReadAsAsync<EmployeeMvc>().Result);


                }

            }
        }

            [HttpPost]
            public ActionResult Edit(EmployeeMvc emp)
            {
            //var webclient = new HttpClient();
            //HttpResponseMessage httpResponseMessage = webclient.PutAsJsonAsync("http://localhost:44305/api/", productModel).Result;
            //return View();
            var webclient = new HttpClient();
            webclient.BaseAddress = new Uri("https://localhost:44305/api/");
            HttpResponseMessage httpResponseMessage = webclient.PutAsJsonAsync("employee",emp ).Result;
             return RedirectToAction("Display");
           }

            public ActionResult Delete(int id)
            {
                var webclient = new HttpClient();
                HttpResponseMessage httpResponseMessage = webclient.DeleteAsync("http://localhost:44305/api/" + id).Result;
            return View();
            }

        
    }
}