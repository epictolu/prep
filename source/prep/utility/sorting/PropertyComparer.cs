using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class PropertyComparer<ItemType, PropertyType> : IComparer<ItemType>
  {
    IComparer<PropertyType> comparer;
    Func<ItemType, PropertyType> accessor;

    public PropertyComparer(IComparer<PropertyType> comparer, Func<ItemType, PropertyType> accessor)
    {
      this.comparer = comparer;
      this.accessor = accessor;
    }

    public int Compare(ItemType x, ItemType y)
    {
      return comparer.Compare(accessor(x), accessor(y));
    }
  }
}