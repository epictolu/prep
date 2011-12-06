using prep.utility;
using prep.utility.filtering;

namespace prep.collections
{
  public interface ICreateMatchers<ItemToMatch, PropertyType>
  {
    IMatchAn<ItemToMatch> equal_to(PropertyType value);
    IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values);
    IMatchAn<ItemToMatch> not_equal_to(PropertyType value);
    IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> criteria);
  }
}