using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static PropertyAccessor<ItemToFilter, PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new PropertyAccessor<ItemToFilter,PropertyType>(property_accessor);
        }
    }
}