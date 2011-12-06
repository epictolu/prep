namespace prep.utility.filtering
{
  public class NegatingMatch<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    IMatchAn<ItemToMatch> to_negate;

    public NegatingMatch(IMatchAn<ItemToMatch> to_negate)
    {
      this.to_negate = to_negate;
    }

    public bool matches(ItemToMatch item)
    {
      return ! to_negate.matches(item);
    }
  }
}