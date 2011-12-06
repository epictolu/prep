using System;
using prep.collections;
using prep.utility.ranges;

namespace prep.utility.filtering
{
  public static class FilteringExtensions
  {
    public static IMatchAn<ItemToMatch> equal_to<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value)
    {
      return equal_to_any(extension_point,value);
    }

    public static IMatchAn<ItemToMatch> equal_to_any<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,params PropertyType[] values)
    {
      return create_using(extension_point,new IsEqualToAny<PropertyType>(values));
    }

    public static IMatchAn<ItemToMatch> not_equal_to<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value)
    {
      return new NegatingMatch<ItemToMatch>(equal_to(extension_point, value));
    }

    public static IMatchAn<ItemToMatch> create_using<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,IMatchAn<PropertyType> criteria)
    {
      return new PropertyCriteria<ItemToMatch, PropertyType>(extension_point.accessor, criteria);
    }
    public static IMatchAn<ItemToMatch> greater_than<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
    {
        return create_using(extension_point,new FallsInRange<PropertyType>(Create.a_range<PropertyType>().GreaterThan(value)));
    }

    public static IMatchAn<ItemToMatch> between<ItemToMatch,PropertyType>(this FilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
    {
        return create_using(extension_point,new FallsInRange<PropertyType>(Create.a_range<PropertyType>().GreaterThanOrEqual(start).LessThanOrEqual(end)));
    }
  }
}
