using CodingChallenge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingChallenge.UI.Controllers
{
    
    public class MoviesController : Controller
    {

        // GET: Movies
        public ILibraryService _service { get; private set; }

        public MoviesController() { }

        public MoviesController(ILibraryService libraryService)
        {
            _service = libraryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMoviesbyTitle(string title)
        {
            var movies = _service.SearchMovieByTitle(title);
            if (movies != null)
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult SearchMovieByFranchise(string franchise)
        {
            var movies = _service.SearchMovieByFranchise(franchise);
            if (movies != null)
            {

            }
            return View();
        }

        public ActionResult GetMoviesByBelowRating(double rating)
        {
            var movies = _service.GetMoviesByBelowRating(rating);
            if (movies != null)
            {

            }
            return View();
        }

        public ActionResult GetMoviesByAboveRating(double rating)
        {
            var movies = _service.GetMoviesByAboveRating(rating);
            if (movies != null)
            {

            }
            return View();
        }

        public ActionResult GetMoviesByDateRange(DateTime startdate, DateTime enddate)
        {
            var movies = _service.GetMoviesByDateRange(startdate, enddate);
            if (movies != null)
            {

            }
            return View();
        }


    }
}