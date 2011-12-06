using System;

namespace prep.utility.filtering
{
  public class FilteringExtensionPoint<ItemToMatch,PropertyType>
  {
    public Func<ItemToMatch, PropertyType> accessor;

    public FilteringExtensionPoint(Func<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }
  }
}