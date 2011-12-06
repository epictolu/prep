using System.Collections;
using System.Collections.Generic;

namespace prep.utility
{
  public class DoublingEnumerable<T> : IEnumerable<T>
  {
    IEnumerable<T> items;

    public DoublingEnumerable(IEnumerable<T> items)
    {
      this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
      foreach (var item in items)
      {
        yield return item;
        yield return item;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}