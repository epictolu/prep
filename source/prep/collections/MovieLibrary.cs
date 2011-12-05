using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_a_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return all_movies_matching(movie => movie.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return
        all_movies_matching(
          movie =>
            movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      foreach (var movie in movies)
        if (movie.production_studio != ProductionStudio.Pixar)
          yield return movie;
    }

    public delegate bool MovieCondition(Movie movie);

    IEnumerable<Movie> all_movies_matching(MovieCondition condition)
    {
      return movies.all_items_matching(new AnonymousMatch<Movie>(x => x.title.StartsWith("A"));
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      return all_movies_matching(
        movie => movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      var desired_movies = new List<Movie>();

      foreach (var movie in movies)
        if (movie.date_published.Year > year)
          desired_movies.Add(movie);

      return desired_movies;
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      var desired_movies = new List<Movie>();

      foreach (var movie in movies)
        if (movie.genre == Genre.kids)
          desired_movies.Add(movie);

      return desired_movies;
    }

    public IEnumerable<Movie> all_action_movies()
    {
      var desired_movies = new List<Movie>();

      foreach (var movie in movies)
        if (movie.genre == Genre.action)
          desired_movies.Add(movie);

      return desired_movies;
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}