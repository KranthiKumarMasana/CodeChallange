using CodingChallenge.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.DataAccess.Interfaces
{
    public interface ILibraryService
    {
        IEnumerable<Movie> SearchMovies(string title, int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending);
        IEnumerable<Movie> SearchMoviesByFranchise(string title, int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending); 
        IEnumerable<Movie> SortMovies(int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending);

        IEnumerable<Movie> GetMoviesList();

        IEnumerable<Movie> SearchMovieByTitle(string title);

        IEnumerable<Movie> SearchMovieByFranchise(string franchise);

        IEnumerable<Movie> GetMoviesByBelowRating(double rating = 5.0);

        IEnumerable<Movie> GetMoviesByAboveRating(double rating = 5.0);


        IEnumerable<Movie> GetMoviesByDateRange(DateTime startdate, DateTime enddate);


        int SearchMoviesCount(string title);
    }
}
