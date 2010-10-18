using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ReadOnlySet<T> : IEnumerable<T>
    {
        IList<T> original;

        public ReadOnlySet(IList<T> original)
        {
            this.original = original;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return original.GetEnumerator();
        }
    }
}