using System;
using System.Linq.Expressions;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter,PropertyType> : CriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType> 
    {
        Func<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> original;
        private Func<ItemToFilter, PropertyType, int> CompareExpression { get { return (x, y) => accessor(x).CompareTo(y); } }

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.accessor = accessor;
            this.original = original;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return GetCriteria(x => CompareExpression(x, value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return GetCriteria(x => CompareExpression(x, start) >= 0 &&
                CompareExpression(x, end) <= 0);
        }
        
        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return original.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return original.not_equal_to(value);
        }

        public Criteria<ItemToFilter> GetCriteria(Predicate<ItemToFilter> criteria_predicate)
        {
            return original.GetCriteria(criteria_predicate);
        }
    }
}