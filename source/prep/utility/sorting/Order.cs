using System;

namespace prep.utility.sorting
{
  public static class Order<ItemType>
  {
    public static ComparerBuilder<ItemType> by_descending<PropertyType>(Func<ItemType, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemType>(new ReverseComparer<ItemType>(by(accessor)));
    }

    public static ComparerBuilder<ItemType> by<PropertyType>(Func<ItemType, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return
        new ComparerBuilder<ItemType>(
          new PropertyComparer<ItemType, PropertyType>(new ComparableComparer<PropertyType>(), accessor));
    }

    public static ComparerBuilder<ItemType> by<PropertyType>(Func<ItemType, PropertyType> accessor,
                                                             params PropertyType[] order)
    {
      return
        new ComparerBuilder<ItemType>(new PropertyComparer<ItemType, PropertyType>(
                                        new FixedComparer<PropertyType>(order), accessor));
    }
  }
}