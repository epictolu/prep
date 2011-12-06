using System;
using prep.utility;

namespace prep.collections
{
  public class ComparableCriteriaFactory<ItemToMatch,PropertyType> where PropertyType : IComparable<PropertyType>
  {
      private readonly CriteriaFactory<ItemToMatch, PropertyType> criteria_factory;
      Func<ItemToMatch, PropertyType> accessor;

    public ComparableCriteriaFactory(CriteriaFactory<ItemToMatch, PropertyType> criteria_factory, Func<ItemToMatch, PropertyType> accessor)
    {
        this.criteria_factory = criteria_factory;
        this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> greater_than(PropertyType value)
    {
      return new AnonymousMatch<ItemToMatch>(x => new IsGreaterThan<PropertyType>(value).matches(accessor(x)));
    }

    public IMatchAn<ItemToMatch> between(PropertyType start,PropertyType end)
    {
      return new AnonymousMatch<ItemToMatch>(x =>
                                               accessor(x).CompareTo(start) >= 0 &&
                                                 accessor(x).CompareTo(end) <= 0);
    }

    public IMatchAn<ItemToMatch> equal_to(PropertyType value)
    {
        return criteria_factory.equal_to_any(value);
    }

    public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
        return criteria_factory.equal_to_any(values);
    }

    public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
    {
        return criteria_factory.not_equal_to(value);
    }
  }
}