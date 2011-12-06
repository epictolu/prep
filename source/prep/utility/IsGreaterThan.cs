using System;

namespace prep.utility
{
  public class IsGreaterThan<T> : IMatchAn<T> where T : IComparable<T>
  {
    T value;

    public IsGreaterThan(T value)
    {
      this.value = value;
    }

    public bool matches(T item)
    {
      return item.CompareTo(value) > 0;
    }
  }
}