using System;
using prep.collections;
using prep.utility.ranges;

namespace prep.utility.filtering
{
  public static class FilteringExtensions
  {
    public static IMatchAn<ItemToMatch> equal_to<ItemToMatch, PropertyType>(
      this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension_point, PropertyType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchAn<ItemToMatch> equal_to_any<ItemToMatch, PropertyType>(
      this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension_point, params PropertyType[] values)
    {
      return extension_point.create_criteria_from(new IsEqualToAny<PropertyType>(values));
    }


    public static IMatchAn<ItemToMatch> greater_than<ItemToMatch, PropertyType>(
      this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension_point, PropertyType value)
      where PropertyType : IComparable<PropertyType>
    {
      return extension_point.create_criteria_from(new FallsInRange<PropertyType>(Create.a_range<PropertyType>().GreaterThan(value)));
    }

    public static IMatchAn<ItemToMatch> between<ItemToMatch, PropertyType>(
      this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension_point, PropertyType start, PropertyType end)
      where PropertyType : IComparable<PropertyType>
    {
      return extension_point.create_criteria_from(new FallsInRange<PropertyType>(
                            Create.a_range<PropertyType>().GreaterThanOrEqual(start).LessThanOrEqual(end)));
    }
  }

  public static class DateFilteringExtensions
  {
    public static IMatchAn<ItemToMatch> greater_than<ItemToMatch>(
      this IProvideAccessToFiltering<ItemToMatch, DateTime> extension_point, int value)
    {
      return
        extension_point.create_criteria_from(
          new FallsInRange<DateTime>(Create.a_range<DateTime>().GreaterThan(new DateTime(value, 1, 1))));
    }
  }
}