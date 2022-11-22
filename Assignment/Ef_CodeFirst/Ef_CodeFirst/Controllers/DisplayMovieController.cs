using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ef_CodeFirst.Models;

namespace Ef_CodeFirst.Controllers
{
    public class DisplayMovieController : Controller
    {
       

        // GET: DisplayMovie
        public ActionResult Index(string value)
        {
            
            List<DisplayMovies> Movie = new List<DisplayMovies>
             {
                 new DisplayMovies(){ MovieName="Seven Samurai", Year=1954},
                 new DisplayMovies(){ MovieName="it's a Wonderful Life", Year=1946},
                 new DisplayMovies(){ MovieName="city of God", Year=2002},
                 new DisplayMovies(){ MovieName="Life is Beautiful", Year=1997},
                 new DisplayMovies(){ MovieName="interstellar", Year=2014},
                 new DisplayMovies(){ MovieName="spirited Away", Year=2014},
                 new DisplayMovies(){ MovieName="the Pianist", Year=2002},
                 new DisplayMovies(){ MovieName="parasite", Year=2002},
                 new DisplayMovies(){ MovieName="The lion King", Year=1994},
             };
            var title = Movie.Where(x => x.Year == (Convert.ToInt32(value)) || value == null).ToList();
            
            return View(title);
        }
    }
}