using System;

namespace prep.utility
{
    public static class CriteriaExtensions
    {
        public static IMatchAn<ItemToMatch> or<ItemToMatch>(this IMatchAn<ItemToMatch> left,
                                                            IMatchAn<ItemToMatch> right)
        {
            return new OrMatch<ItemToMatch>(left, right);
        }

        public static IMatchAn<ItemToMatch> equal_to<ItemToMatch, Property>(this Func<ItemToMatch, Property> match, Property property)
        {
            return new AnonymousMatch<ItemToMatch>(item => match(item).Equals(property));
        }
    }
}