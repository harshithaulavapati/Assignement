using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_Mvc.Models;

namespace Assignment_Mvc.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities nt = new NorthwindEntities();
        // GET: Code
        public ActionResult Index(string country)
        {
            
            return View(nt.Customers.ToList() );
        }
        public ActionResult displaycountry()
        {
           
            var query = from c in nt.Customers
            where c.Country == "Germany"
            select new { c.CustomerID, c.Country };
            return View(query);

           

        }
        public actionresult order()
        {
            //one method
            var query=from d in nt.orders
                      where c.orderid=="10248"
                      select new {c.customerID,c.orderid}
                      return view(query);
            //another method
           List < order > ord = (from c in db.orders
                                orderby c.customerid
                                select c.orderid == "10248").ToList();
            return View(ord);
        }

    }
}