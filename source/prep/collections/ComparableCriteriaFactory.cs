using System;
using prep.utility;

namespace prep.collections
{
  public class ComparableCriteriaFactory<ItemToMatch,PropertyType> where PropertyType : IComparable<PropertyType>
  {
    Func<ItemToMatch, PropertyType> accessor;

    public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> greater_than(PropertyType value)
    {
        return new GreaterThanMatch<ItemToMatch, PropertyType>(accessor, value);
    }
  }
}