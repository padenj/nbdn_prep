using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertyAccessor<ItemToFilter, PropertyType>
    {
        private Func<ItemToFilter, PropertyType> _propertyAccessor;

        public PropertyAccessor(Func<ItemToFilter, PropertyType> propertyAccessor)
        {
            _propertyAccessor = propertyAccessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType propertyToEvaluate)
        {
            return new AnonymousCriteria<ItemToFilter>(x => _propertyAccessor(x).Equals(propertyToEvaluate));
        }
    }
}