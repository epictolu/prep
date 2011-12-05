using System;
using System.Collections.Generic;

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
      return this.movies;
    }

    public void add(Movie movie)
    {
        foreach (var existingMovie in movies)
            if (existingMovie == movie || existingMovie.title == movie.title)
                return;

        movies.Add(movie);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        var desired_movies = new List<Movie>();

        foreach (var movie in movies)
            if (movie.production_studio == ProductionStudio.Pixar)
                desired_movies.Add(movie);

        return desired_movies;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        var desired_movies = new List<Movie>();

        foreach (var movie in movies)
            if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney)
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

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
        var desired_movies = new List<Movie>();

        foreach (var movie in movies)
            if (movie.production_studio != ProductionStudio.Pixar)
                desired_movies.Add(movie);

        return desired_movies;
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
        var desired_movies = new List<Movie>();

        foreach (var movie in movies)
            if (movie.date_published.Year > year)
                desired_movies.Add(movie);

        return desired_movies;
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
        var desired_movies = new List<Movie>();

        foreach (var movie in movies)
            if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                desired_movies.Add(movie);

        return desired_movies;
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