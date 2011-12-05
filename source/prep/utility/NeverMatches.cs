namespace prep.utility
{
  public class NeverMatches<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    public bool matches(ItemToMatch item)
    {
      return false;
    }
  }
}