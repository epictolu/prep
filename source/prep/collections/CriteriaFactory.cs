using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.collections
{
  public class CriteriaFactory<ItemToMatch, PropertyType>
  {
    Func<ItemToMatch, PropertyType> accessor;

    public CriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> equal_to(PropertyType type)
    {
      return new AnonymousMatch<ItemToMatch>(x => Equals(accessor(x), type));
    }

    public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
      return new AnonymousMatch<ItemToMatch>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
    {
      throw new NotImplementedException();
    }
  }
}