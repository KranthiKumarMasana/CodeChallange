using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using CodingChallenge.DataAccess.Interfaces;
using CodingChallenge.DataAccess.Models;
using CodingChallenge.Utilities;


public class LibraryService : ILibraryService
{
    public LibraryService() { }

    public static List<Movie> movies => allMovies;

    static List<Movie> allMovies = new List<Movie>()
        {
            new Movie()
            {
                ID=1,
                Title="The NeverEnding Story",
                Year=1978,
                Rating=7.5,
                Franchise="The NeverEnding"
            },
             new Movie()
            {
                ID=1,
                Title="The NeverEnding Story1",
                Year=1978,
                Rating=7.5,
                Franchise="The NeverEnding"
            },
              new Movie()
            {
                ID=2,
                Title="The NeverEnding Story2",
                Year=1978,
                Rating=7.5,
                Franchise="The NeverEnding"
            },
               new Movie()
            {
                ID=3,
                Title="The NeverEnding Story3",
                Year=1978,
                Rating=7.5,
                Franchise="The NeverEnding"
            },
                new Movie()
            {
                ID=4,
                Title="The NeverEnding Story4",
                Year=1978,
                Rating=7.5,
                Franchise="The NeverEnding"
            },
        };
    private IEnumerable<Movie> GetMovies()
    {
        // return _movies ?? (_movies = ConfigurationManager.AppSettings["LibraryPath"].FromFileInExecutingDirectory().DeserializeFromXml<Library>().Movies);

        return allMovies;


    }
    private IEnumerable<Movie> _movies { get; set; }

    //public int SearchMoviesCount(string title)
    //{
    //    return SearchMovies(title).Count();
    //}
    public IEnumerable<Movie> GetMoviesList()
    {
        //var movies = GetMovies().Where(s => s.Title.ToLower().Contains(title));
        var movies = GetMovies();
        var results = RemoveDuplicates.RemoveDuplicatesMovies(movies.ToList());
        return results.ToList();//.Distinct(new RemoveDuplicates());
    }

    //public IEnumerable<Movie> SearchMovies(string title, int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending)
    //{
    //    //var movies = GetMovies().Where(s => s.Title.ToLower().Contains(title));
    //    var movies = GetMovies().Where(x => x.Title.ToLower().Contains(title));
    //    if (skip.HasValue && take.HasValue)
    //    {
    //        movies = movies.Skip(skip.Value).Take(take.Value);
    //    }
    //    var results = RemoveDuplicates.RemoveDuplicatesMovies(movies.ToList());
    //    return results.ToList();//.Distinct(new RemoveDuplicates());
    //}

    //public IEnumerable<Movie> SortMovies(int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending)
    //{
    //    var movies = GetMovies();
    //    List<Movie> obj = CodingChallenge.Utilities.StringComparer.CreateSortList<Movie>(movies, sortColumn, sortDirection);
    //    var results = RemoveDuplicates.RemoveDuplicatesMovies(movies.ToList());
    //    return results.ToList().Skip(skip.Value).Take(take.Value);

    //}




    public IEnumerable<Movie> SearchMovieByTitle(string title)
    {
        var movies = GetMovies().Where(x => x.Title.ToLower().Contains(title));
        if (movies != null)
            return movies.ToList();
        else
            return Enumerable.Empty<Movie>();
    }


    public IEnumerable<Movie> SearchMovieByFranchise(string franchise)
    {
        var movies = GetMovies().Where(x => x.Franchise.ToLower() == franchise);
        if (movies != null)
            return movies.ToList();
        else
            return Enumerable.Empty<Movie>();
    }


    public IEnumerable<Movie> GetMoviesByBelowRating(double rating)
    {
        var movies = GetMovies().Where(x => x.Rating <= rating);
        if (movies != null)
            return movies.ToList();
        else
            return Enumerable.Empty<Movie>();
    }

    public IEnumerable<Movie> GetMoviesByAboveRating(double rating)
    {
        var movies = GetMovies().Where(x => x.Rating >= rating);
        if (movies != null)
            return movies.ToList();
        else
            return Enumerable.Empty<Movie>();
    }


    public IEnumerable<Movie> GetMoviesByDateRange(DateTime startdate, DateTime enddate)
    {

        if (startdate != default(DateTime) && enddate != default(DateTime))
        {
            var movies = GetMovies();
            movies = GetMovies().Where(x => x.Year >= startdate.Year && x.Year < enddate.Year);
            return movies.ToList();

        }
        return Enumerable.Empty<Movie>();
    }
}

