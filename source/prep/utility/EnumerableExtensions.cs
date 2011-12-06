using System;
using System.Collections.Generic;
using prep.utility.filtering;
using prep.utility.sorting;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      return new LazyEnumerable<T>(items);
    }

    public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,IMatchAn<ItemToMatch> specification)
    {
      return items.all_items_matching(specification.matches);
    }
    static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,Condition<ItemToMatch> condition)
    {
      return new FilteringEnumerable<ItemToMatch>(items, condition);
    }

    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
    {
      var sorted = new List<T>(items);
      sorted.Sort(comparer);
      return sorted;
    }

      public static IEnumerable<ItemType> sort_by<ItemType, PropertyType>(this IEnumerable<ItemType> items, Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
      {
          return items.sort_using(GetComparerBuilder(accessor));
      }

      public static IEnumerable<ItemType> sort_by_descending<ItemType, PropertyType>(this IEnumerable<ItemType> items, Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
      {
          return items.sort_using(GetComparerBuilder(accessor).reverse());
      }

      private static ComparerBuilder<ItemType> GetComparerBuilder<ItemType, PropertyType>(Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType> where PropertyType : IComparable<PropertyType>
      {
          return new ComparerBuilder<ItemType>(Order<ItemType>.by(accessor));
      }
  }
}