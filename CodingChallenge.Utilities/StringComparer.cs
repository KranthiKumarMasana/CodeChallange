using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.DataAccess;
using CodingChallenge.DataAccess.Models;

namespace CodingChallenge.Utilities
{
    public static class StringComparer
    {

        public static List<T> CreateSortList<T>(IEnumerable<T> dataSource,
                 string fieldName, SortDirection sortDirection)
        {
            List<T> returnList = new List<T>();
            returnList.AddRange(dataSource);
            PropertyInfo propInfo = typeof(T).GetProperty(fieldName);
            Comparison<T> compare = delegate (T a, T b)
            {
                bool asc = sortDirection == SortDirection.Ascending;
                object valueA = asc ? propInfo.GetValue(a, null).ToString().Replace("a", "").Replace("the", "").Replace("an", "") : propInfo.GetValue(b, null).ToString().Replace("a", "").Replace("the", "").Replace("an", "");
                object valueB = asc ? propInfo.GetValue(b, null).ToString().Replace("a", "").Replace("the", "").Replace("an", "") : propInfo.GetValue(a, null).ToString().Replace("a", "").Replace("the", "").Replace("an", "");

                return valueA is IComparable ? ((IComparable)valueA).CompareTo(valueB) : 0;
            };



            returnList.Sort(compare);
            return returnList;
        }
    }

    public sealed class SCompare : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
        }
    }
}
