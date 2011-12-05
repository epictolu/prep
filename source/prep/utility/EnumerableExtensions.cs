using System.Collections.Generic;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_a_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items)
        yield return item;
    }

    public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,Condition<ItemToMatch> condition)
    {
      foreach (var item in items)
        if (condition(item)) yield return item;
    }
  }
}