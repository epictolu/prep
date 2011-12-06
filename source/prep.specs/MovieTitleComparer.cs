using System.Collections.Generic;
using prep.collections;

namespace prep.specs
{
  public class MovieTitleComparer : IComparer<Movie>
  {
    public int Compare(Movie x, Movie y)
    {
      return x.title.CompareTo(y.title);
    }
  }
}