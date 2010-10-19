using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nothinbutdotnetprep.specs
{
    public interface SomeContract<T>
    {
        IEnumerable<T> where(Expression<Func<T, bool>> expression );

    }
}