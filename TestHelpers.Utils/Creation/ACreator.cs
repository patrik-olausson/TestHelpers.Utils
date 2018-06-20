using System;
using System.Collections.Generic;

namespace TestHelpers.Utils
{
    public class ACreator
    {
        public DateBuilder Date(int offset)
        {
            return new DateBuilder(offset);
        }

        public IReadOnlyCollection<T> SetOf<T>(params T[] items)
        {
            return items;
        }
    }

    
}
