using System;

namespace prep.utility
{
    public class GreaterThanMatch<ItemToMatch, PropertyType> : IMatchAn<ItemToMatch> where PropertyType : IComparable<PropertyType>
    {
        private readonly Func<ItemToMatch, PropertyType> accessor;
        private readonly PropertyType value;

        public GreaterThanMatch(Func<ItemToMatch, PropertyType> accessor, PropertyType value)
        {
            this.accessor = accessor;
            this.value = value;
        }

        public bool matches(ItemToMatch item)
        {
            return accessor(item).CompareTo(value) > 0;
        }
    }
}