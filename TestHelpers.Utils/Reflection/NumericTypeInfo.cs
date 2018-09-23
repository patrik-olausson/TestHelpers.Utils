using System;

namespace TestHelpers.Utils.Reflection
{
    public class NumericTypeInfo
    {
        public string Alias { get; }
        public string Suffix { get; }

        public NumericTypeInfo(string alias, string suffix = null)
        {
            Alias = alias ?? throw new ArgumentNullException(nameof(alias));
            Suffix = suffix ?? string.Empty;
        }
    }
}