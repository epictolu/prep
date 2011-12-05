namespace prep.utility
{
  public class AnonymousMatch<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    Condition<ItemToMatch> condition ;

    public AnonymousMatch(Condition<ItemToMatch> condition)
    {
      this.condition = condition;
    }

    public bool matches(ItemToMatch item)
    {
      return condition(item);
    }
  }
}