using System;
using prep.utility.filtering;
using prep.utility.ranges;

namespace prep.collections
{
  public class ComparableCriteriaFactory<ItemToMatch, PropertyType> : ICreateMatchers<ItemToMatch,PropertyType> where PropertyType : IComparable<PropertyType>
  {
    ICreateMatchers<ItemToMatch, PropertyType> original;

    public ComparableCriteriaFactory(ICreateMatchers<ItemToMatch, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToMatch> equal_to(PropertyType value)
    {
      return original.equal_to(value);
    }

    public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
      return original.equal_to_any(values);
    }

    public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
    {
      return original.not_equal_to(value);
    }

    public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> criteria)
    {
      return original.create_using(criteria);
    }

    public IMatchAn<ItemToMatch> greater_than(PropertyType value)
    {
        return original.create_using(new FallsInRange<PropertyType>(Create.a_range<PropertyType>().GreaterThan(value)));
    }

    public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
    {
        return original.create_using(new FallsInRange<PropertyType>(Create.a_range<PropertyType>().GreaterThanOrEqual(start).LessThanOrEqual(end)));
    }
  }
}
