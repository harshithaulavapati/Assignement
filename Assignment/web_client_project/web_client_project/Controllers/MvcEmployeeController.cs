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
    public class MvcEmployeeController : Controller
    {
        // GET: MvcEmployee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            IEnumerable<MvcEmployee> emplist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44305/api/");
                var responsetask = webclient.GetAsync("employee");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    emplist = JsonConvert.DeserializeObject<List<MvcEmployee>>(resultdata);
                }
                else
                {
                    emplist = Enumerable.Empty<MvcEmployee>();
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
        public ActionResult Create(MvcEmployee mov)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44305/api/");
                var posttask = webclient.PostAsJsonAsync<MvcEmployee>("employee", mov);
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

    }
}