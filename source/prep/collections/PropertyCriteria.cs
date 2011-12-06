using System;
using prep.utility;
using prep.utility.filtering;

namespace prep.collections
{
  public class PropertyCriteria<ItemToMatch,PropertyType> : IMatchAn<ItemToMatch>
  {
    public Func<ItemToMatch, PropertyType> accessor { get; private set; }
    IMatchAn<PropertyType> real_condition;

    public PropertyCriteria(Func<ItemToMatch, PropertyType> accessor, IMatchAn<PropertyType> real_condition)
    {
      this.accessor = accessor;
      this.real_condition = real_condition;
    }

    public bool matches(ItemToMatch item)
    {
      return real_condition.matches(accessor(item));

    }
  }
}