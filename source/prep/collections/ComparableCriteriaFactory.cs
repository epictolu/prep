using System;
using prep.utility;

namespace prep.collections
{
  public class ComparableCriteriaFactory<ItemToMatch, PropertyType> : ICreateMatchers<ItemToMatch, PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    Func<ItemToMatch, PropertyType> accessor;
    ICreateMatchers<ItemToMatch, PropertyType> original;

    public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> accessor,
                                     ICreateMatchers<ItemToMatch, PropertyType> original)
    {
      this.accessor = accessor;
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

    public IMatchAn<ItemToMatch> greater_than(PropertyType value)
    {
      return MatchFactory<ItemToMatch>.AnonymousMatchWith(x => new IsGreaterThan<PropertyType>(value).matches(accessor(x)));
    }

    public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
    {
      return MatchFactory<ItemToMatch>.AnonymousMatchWith(x =>
                                               accessor(x).CompareTo(start) >= 0 &&
                                                 accessor(x).CompareTo(end) <= 0);
    }
  }
}