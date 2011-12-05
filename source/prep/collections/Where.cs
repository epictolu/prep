using System;
using prep.utility;

namespace prep.collections
{
    public class Where<ItemToMatch>
    {
        public static MyClass<ItemToMatch,PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            return new MyClass<ItemToMatch,PropertyType>(accessor);
        }


    }
    public class MyClass<ItemToMatch, PropertyType>
    {
        private readonly Func<ItemToMatch, PropertyType> accessor;

        public MyClass(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType type)
        {
            return new AnonymousMatch<ItemToMatch>(x => Equals(accessor(x), type));
        }
    }
}
