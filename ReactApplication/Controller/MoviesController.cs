using CodingChallenge.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodingChallenge.UI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _service.GetMoviesList();
            return Ok();
        }

        [HttpPost]
        public IActionResult GetMoviesbyTitle(string title)
        {
            var movies = _service.SearchMovieByTitle(title);
            if (movies != null)
            {

            }
            return Ok();
        }

        [HttpPost]
        public IActionResult SearchMovieByFranchise(string franchise)
        {
            var movies = _service.SearchMovieByFranchise(franchise);
            if (movies != null)
            {

            }
            return Ok();
        }

        public IActionResult GetMoviesByBelowRating(double rating)
        {
            var movies = _service.GetMoviesByBelowRating(rating);
            if (movies != null)
            {

            }
            return Ok();
        }

        public IActionResult GetMoviesByAboveRating(double rating)
        {
            var movies = _service.GetMoviesByAboveRating(rating);
            if (movies != null)
            {

            }
            return Ok();
        }

        public IActionResult GetMoviesByDateRange(DateTime startdate, DateTime enddate)
        {
            var movies = _service.GetMoviesByDateRange(startdate, enddate);
            if (movies != null)
            {

            }
            return Ok();
        }


    }
}