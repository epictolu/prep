using System;
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
      throw new NotImplementedException();
    }
  }
}