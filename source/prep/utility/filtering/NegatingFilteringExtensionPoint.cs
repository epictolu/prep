namespace prep.utility.filtering
{
  public class NegatingFilteringExtensionPoint<ItemToMatch,PropertyType> : IProvideAccessToFiltering<ItemToMatch,PropertyType>
  {
    IProvideAccessToFiltering<ItemToMatch, PropertyType> original;

    public NegatingFilteringExtensionPoint(IProvideAccessToFiltering<ItemToMatch, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToMatch> create_criteria_from(IMatchAn<PropertyType> criteria)
    {
      return new NegatingMatch<ItemToMatch>(original.create_criteria_from(criteria));
    }
  }
}