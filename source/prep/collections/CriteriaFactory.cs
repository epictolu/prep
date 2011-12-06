using System;
using prep.utility.filtering;

namespace prep.collections
{
  public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateMatchers<ItemToMatch, PropertyType>
  {
    Func<ItemToMatch, PropertyType> accessor;

    public CriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
      return create_using(new IsEqualToAny<PropertyType>(values));
    }

    public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
    {
      return new NegatingMatch<ItemToMatch>(equal_to(value));
    }


    public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> criteria)
    {
      return new PropertyCriteria<ItemToMatch, PropertyType>(accessor, criteria);
    }
  }
}