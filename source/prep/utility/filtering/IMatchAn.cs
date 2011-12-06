namespace prep.utility.filtering
{
  public interface IMatchAn<Item>
  {
    bool matches(Item item);
  }
}