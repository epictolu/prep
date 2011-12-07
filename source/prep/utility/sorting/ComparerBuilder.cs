using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
  {
    IComparer<ItemToSort> comparer;

    public ComparerBuilder(IComparer<ItemToSort> comparer)
    {
      this.comparer = comparer;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return comparer.Compare(x, y);
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(comparer, Order<ItemToSort>.by(accessor)));
    }

      public ComparerBuilder<ItemToSort> reverse()
      {
          return new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(comparer));
      }
  }
}