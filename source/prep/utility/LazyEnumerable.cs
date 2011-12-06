using System.Collections;
using System.Collections.Generic;

namespace prep.utility
{
  public class LazyEnumerable<T> : IEnumerable<T>
  {
    IEnumerable<T> items;

    public LazyEnumerable(IEnumerable<T> items)
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