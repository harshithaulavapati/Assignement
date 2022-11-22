using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Ef_CodeFirst.Models
{
    public class MovieContext :DbContext
    {
        public MovieContext() : base("name=Movies")
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}