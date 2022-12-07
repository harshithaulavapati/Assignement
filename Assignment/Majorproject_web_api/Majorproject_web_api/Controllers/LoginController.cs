using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Majorproject_web_api.Models;

namespace Majorproject_web_api.Controllers
{
   
    public class LoginController : Controller
    {
        EmployeetravelbookingsystemEntities et = new EmployeetravelbookingsystemEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Autherize(User adminlogin)
        {

            using (EmployeetravelbookingsystemEntities db = new EmployeetravelbookingsystemEntities())
            {
                var obj = db.Users.Where(a => a.User_id == adminlogin.User_id && a.Password == adminlogin.Password).FirstOrDefault();
                if (obj == null)
                {
                    TempData["SuccessMessage"] = "wrong username and password: plese provide correct login data!!";
                    adminlogin.loginErrorMessage = "wrong username and password: plese provide correct login data!!";
                    return View("Index", adminlogin);
                }
                else if (adminlogin.User_id == "" || adminlogin.Password == "")
                {
                    TempData["SuccessMessage"] = "Please Provid Username and Password";
                    return View("Index", adminlogin);
                }
                else
                {
                    //Session["aid"] = obj.aid;
                    Session["username"] = obj.User_id;
                    TempData["SuccessMessage"] = "You are Successfully Loggin as Admin " + adminlogin.User_id.ToString();
                    return RedirectToAction("Index", "Home");

                }

            }
        }
        // systm logout
        public ActionResult logout(User adminlog)
        {
            int aid = (int)Session["aid"];
            Session.Abandon();
            TempData["BadMsg"] = "You are Successfully Logout as Admin " + adminlog.username.ToString();
            return RedirectToAction("Index", "AdminLogin");

        }
    }
}
    
