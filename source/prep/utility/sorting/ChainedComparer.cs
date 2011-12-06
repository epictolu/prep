using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class ChainedComparer<T> : IComparer<T>
  {
    IComparer<T> first;
    IComparer<T> second;

    public ChainedComparer(IComparer<T> first, IComparer<T> second)
    {
      this.first = first;
      this.second = second;
    }

    public int Compare(T x, T y)
    {
      var compared_result = first.Compare(x, y);
      return compared_result == 0 ? second.Compare(x, y) : compared_result;
    }
  }
}