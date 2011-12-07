using System;
using System.Collections;
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
          return items.sort_using(Order<ItemType>.by(accessor));
      }

      public static SortingEnumerable<ItemType> sort_by<ItemType, PropertyType>(this IEnumerable<ItemType> items,  Func<ItemType, PropertyType> accessor, params PropertyType[] parameters) 
      {
          return new SortingEnumerable<ItemType>(items, Order<ItemType>.by(accessor, parameters));
      }

      public static IEnumerable<ItemType> then_by<ItemType, PropertyType>(this SortingEnumerable<ItemType> items, Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
      {
          return new SortingEnumerable<ItemType>(items, items.comparer_builder.then_by(accessor));
      }

      public static IEnumerable<ItemType> sort_by_descending<ItemType, PropertyType>(this IEnumerable<ItemType> items, Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
      {
          return items.sort_using(Order<ItemType>.by_descending(accessor));
      }
  }

    public class SortingEnumerable<ItemType> : IEnumerable<ItemType>
    {
        IEnumerable<ItemType> enumerable;
        public ComparerBuilder<ItemType> comparer_builder;

        public SortingEnumerable(IEnumerable<ItemType> enumerable, ComparerBuilder<ItemType> comparer_builder)
        {
            this.enumerable = enumerable;
            this.comparer_builder = comparer_builder;
        }

        public IEnumerator<ItemType> GetEnumerator()
        {
            return enumerable.sort_using(comparer_builder).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}