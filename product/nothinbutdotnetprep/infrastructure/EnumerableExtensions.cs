using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items,
                                                                 Criteria<Item> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.is_satisfied_by(item)) yield return item;
            }
        }

        public static IEnumerable<Item> one_at_a_time<Item>(this IEnumerable<Item> items)
        {
            foreach (var item in items) yield return item;
        }
    }
}