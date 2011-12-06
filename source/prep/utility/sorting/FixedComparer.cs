using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class FixedComparer<T> : IComparer<T>
  {
    IList<T> order;

    public FixedComparer(params T[] order)
    {
      this.order = new List<T>(order);
    }

    public int Compare(T x, T y)
    {
      return order.IndexOf(x).CompareTo(order.IndexOf(y));
    }
  }
}