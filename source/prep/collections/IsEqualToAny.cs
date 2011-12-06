using System.Collections.Generic;
using prep.utility;
using prep.utility.filtering;

namespace prep.collections
{
  public class IsEqualToAny<T> : IMatchAn<T>
  {
    IList<T> items;

    public IsEqualToAny(params T[] items)
    {
      this.items = new List<T>(items);
    }

    public bool matches(T item)
    {
      return items.Contains(item);
    }
  }
}