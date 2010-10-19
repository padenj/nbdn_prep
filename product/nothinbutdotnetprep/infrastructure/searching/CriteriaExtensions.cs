namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left, Criteria<T> right)
        {
            return new OrCriteria<T>(left, right);
        }

        public static Criteria<T> not<T>(this Criteria<T> to_negate)
        {
            return new NotCriteria<T>(to_negate);
        }
    }
}