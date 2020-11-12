using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.DataAccess.Models;
namespace CodingChallenge.Utilities
{
    public static class RemoveDuplicates //: IEqualityComparer<Movie>
    {
        //public bool Equals(Movie x, Movie y)
        //{
        //    return x.ID == y.ID &&
        //        x.Title == y.Title &&
        //        x.Year == y.Year &&
        //        x.Rating == y.Rating;
        //}

        //public int GetHashCode(Movie obj)
        //{
        //    return obj.ID.GetHashCode() ^
        //        obj.Title.GetHashCode() ^
        //        obj.Year.GetHashCode() ^
        //        obj.Rating.GetHashCode();
        //}

        public static IEnumerable<Movie> RemoveDuplicatesMovies(List<Movie> obj)
        {
            var distinct = obj.GroupBy(l => new { l.Title, l.Rating, l.Year, l.Franchise }).Select(d => new Movie
            {
                ID = d.First().ID,
                Title = d.Key.Title,
                Rating = d.Key.Rating,
                Year = d.Key.Year,
                Franchise = d.Key.Franchise
            });

            return distinct;
        }

    }
}
