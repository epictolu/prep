using prep.utility;

namespace prep.collections
{
    public static class MatchFactory<ItemToMatch>
    {
        public static IMatchAn<ItemToMatch> AnonymousMatchWith(Condition<ItemToMatch> condition)
        {
            return new AnonymousMatch<ItemToMatch>(condition);
        }
    }
}