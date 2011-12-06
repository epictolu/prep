﻿using System;

namespace prep.collections
{
  public class Where<ItemToMatch>
  {
    public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
      Func<ItemToMatch, PropertyType> accessor)
    {
      return new CriteriaFactory<ItemToMatch, PropertyType>(accessor);
    }

    public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
      Func<ItemToMatch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(accessor, has_a(accessor));
    }
  }
}