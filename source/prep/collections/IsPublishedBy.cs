using prep.utility;

namespace prep.collections
{

  public class IsPublishedBy : IMatchAn<Movie>
  {
    ProductionStudio studio;

    public IsPublishedBy(ProductionStudio studio)
    {
      this.studio = studio;
    }

    public bool matches(Movie movie)
    {
      return movie.production_studio != studio;
    } 
  }
}