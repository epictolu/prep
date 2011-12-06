using System.Collections;
using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility
{
  public class FilteringEnumerable<T> : IEnumerable<T>
  {
    IEnumerable<T> items;
    Condition<T> condition;

    public FilteringEnumerable(IEnumerable<T> items, Condition<T> condition)
    {
      this.items = items;
      this.condition = condition;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      foreach (var item in items)
        if (condition(item)) yield return item;
    }
  }
}