using prep.utility;

namespace prep.collections
{
  public interface ICreateMatchers<ItemToMatch, PropertyType>
  {
    IMatchAn<ItemToMatch> equal_to(PropertyType value);
    IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values);
    IMatchAn<ItemToMatch> not_equal_to(PropertyType value);
  }
}