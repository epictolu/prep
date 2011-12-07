using System;
using System.Collections;
using System.Collections.Generic;
using prep.utility.sorting;

namespace prep.utility
{
  public class SortingEnumerable<ItemType> : IEnumerable<ItemType>
  {
    IEnumerable<ItemType> original_set;
    public ComparerBuilder<ItemType> comparer_builder;

    public SortingEnumerable(IEnumerable<ItemType> original_set, ComparerBuilder<ItemType> comparer_builder)
    {
      this.original_set = original_set;
      this.comparer_builder = comparer_builder;
    }

    public IEnumerator<ItemType> GetEnumerator()
    {
      var sorted = new List<ItemType>(original_set);
      sorted.Sort(comparer_builder);
      return sorted.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public SortingEnumerable<ItemType> then_by<PropertyType>(Func<ItemType, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new SortingEnumerable<ItemType>(this, comparer_builder.then_by(accessor));
    }
  }
}