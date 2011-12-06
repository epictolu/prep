using System;
using prep.collections;

namespace prep.utility.filtering
{
  public class FilteringExtensionPoint<ItemToMatch, PropertyType> : IProvideAccessToFiltering<ItemToMatch, PropertyType>
  {
    Func<ItemToMatch, PropertyType> accessor; 

    public FilteringExtensionPoint(Func<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToFiltering<ItemToMatch, PropertyType> not
    {
      get
      {
        return new NegatingFilteringExtensionPoint<ItemToMatch, PropertyType>(this);
      }
    }

    public IMatchAn<ItemToMatch> create_criteria_from(IMatchAn<PropertyType> criteria)
    {
      return new PropertyCriteria<ItemToMatch, PropertyType>(accessor, criteria);
    }
  }

  public interface IProvideAccessToFiltering<ItemToMatch, PropertyType>
  {
    IMatchAn<ItemToMatch> create_criteria_from(IMatchAn<PropertyType> criteria);
  }
}