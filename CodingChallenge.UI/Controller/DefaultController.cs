using System;
using System.Linq;
using System.Web.Mvc;
using CodingChallenge.DataAccess;
using CodingChallenge.DataAccess.Interfaces;
using CodingChallenge.UI.Models;

namespace CodingChallenge.UI.Controllers
{
    public class DefaultController : Controller
    {
        public ILibraryService LibraryService { get; private set; }

        public DefaultController() { }

        public DefaultController(ILibraryService libraryService)
        {
            LibraryService = libraryService;
        }

        public ActionResult Index([ModelBinder(typeof(GridBinder))]GridOptions options, string searchString, string SearchFranchise)
        {
            options.TotalItems = LibraryService.SearchMoviesCount("");
            if (options.SortColumn == null)
                options.SortColumn = "ID";
            var model = new MovieListViewModel();
            if (!String.IsNullOrEmpty(searchString))
            {
                model.GridOptions = options;
                model.Movies = LibraryService.SearchMovies(searchString, (options.Page - 1) * options.ItemsPerPage, options.ItemsPerPage, options.SortColumn, options.SortDirection).ToList();
            }
            else if (!String.IsNullOrEmpty(SearchFranchise))
            {

                model.GridOptions = options;
                model.Movies = LibraryService.SearchMoviesByFranchise(SearchFranchise, (options.Page - 1) * options.ItemsPerPage, options.ItemsPerPage, options.SortColumn, options.SortDirection).ToList();
            }
            else
            {
                model.GridOptions = options;
                model.Movies = LibraryService.SortMovies((options.Page - 1) * options.ItemsPerPage, options.ItemsPerPage, options.SortColumn, options.SortDirection).ToList();

            }

            return View(model);
        }


    }
}
