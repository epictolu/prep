using System;

namespace prep.utility.filtering
{
    public class FilteringExtensionPoint<ItemToMatch, PropertyType> : INegatedFilteringExtensionPoint<ItemToMatch, PropertyType>
    {
        public Func<ItemToMatch, PropertyType> accessor { get; private set; }

        public FilteringExtensionPoint(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public INegatedFilteringExtensionPoint<ItemToMatch, PropertyType> not
        {
            get { return this; }
        }
    }

    public interface INegatedFilteringExtensionPoint<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor { get; }
    }
}