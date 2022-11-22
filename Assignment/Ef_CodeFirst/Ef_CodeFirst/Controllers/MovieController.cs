using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ef_CodeFirst.Models;

namespace Ef_CodeFirst.Controllers
{
    public class MovieController : Controller
    {
        MovieContext mc = new MovieContext();
        // GET: Movie
        public ActionResult Index()
        {
            return View((mc.Movies.ToList()));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Movie movie)
        {
            mc.Movies.Add(movie);
            mc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie m = mc.Movies.Find(id);
            return View(m);
        }

        // edit of movies
        public ActionResult Edit(Movie m)
        {
            Movie mv = mc.Movies.Find(m.MovieId);
            mv.MovieName = m.MovieName;
            mv.Dateofrelease = m.Dateofrelease;
            mc.SaveChanges();
            return RedirectToAction("Index");
        }
        //delete a movies
        public ActionResult Delete(int id)
        {
            Movie m = mc.Movies.Find(id);
            mc.Movies.Remove(m);
            mc.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get Details of a movies Id
        public ActionResult Details(int id)
        {
            Movie m = mc.Movies.Find(id);
            return View(m);
        }
    }
}
