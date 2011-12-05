using System;

namespace prep.collections
{
    public class Where<ItemToMatch>
    {
        public static CriteriaFactory<ItemToMatch,PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToMatch,PropertyType>(accessor);
        }


    }
}
