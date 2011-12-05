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
        IMatchAn<ItemToMatch> match = new AnonymousMatch<ItemToMatch>(x => false);

        foreach(var value in values)
            match = new OrMatch<ItemToMatch>(match, equal_to(value));

        return match;
    }
  }
}