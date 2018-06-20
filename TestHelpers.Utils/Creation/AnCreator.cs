using System.Collections.Generic;

namespace TestHelpers.Utils
{
    public class AnCreator
    {
        public IReadOnlyCollection<T> EmptySetOf<T>()
        {
            return new T[0];
        }
    }
}