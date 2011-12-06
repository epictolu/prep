namespace prep.utility.filtering
{
  public class NeverMatches<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    public bool matches(ItemToMatch item)
    {
      return false;
    }
  }
}