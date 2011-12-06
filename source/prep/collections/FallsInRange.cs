using System;
using prep.utility.filtering;
using prep.utility.ranges;

namespace prep.collections
{
  public class FallsInRange<T> : IMatchAn<T> where T : IComparable<T>
  {
    Range<T> range;

    public FallsInRange(Range<T> range)
    {
      this.range = range;
    }

    public bool matches(T item)
    {
      return range.contains(item);
    }
  }
}