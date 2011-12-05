namespace prep.utility
{
  public class OrMatch<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    IMatchAn<ItemToMatch> left_side;
    IMatchAn<ItemToMatch> right_side;

    public OrMatch(IMatchAn<ItemToMatch> left_side, IMatchAn<ItemToMatch> right_side)
    {
      this.left_side = left_side;
      this.right_side = right_side;
    }

    public bool matches(ItemToMatch item)
    {
      return left_side.matches(item) || right_side.matches(item);
    }
  }
}