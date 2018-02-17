using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies;

        public MoviesController()
        {
            _movies = new List<Movie>
            {
                new Movie{ Id=1, Name="Shrek" },
                new Movie{ Id=2, Name="Wall-e" }
            };

        }

        public ActionResult Index()
        {
            return View(_movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id==id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}