using System.Collections;
using System.Collections.Generic;

namespace prep.collections
{
  public class ReadOnlySetOf<T> : IEnumerable<T>
  {
    IEnumerable<T> items;

    public ReadOnlySetOf(IEnumerable<T> items)
    {
      this.items = items;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return items.GetEnumerator();
    }
  }
}