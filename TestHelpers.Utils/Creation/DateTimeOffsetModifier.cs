using System;

namespace TestHelpers.Utils
{
    public class DateTimeOffsetModifier
    {
        private readonly int offset;
        private readonly Func<DateTimeOffset, int, DateTimeOffset> modifierFunction;

        public DateTimeOffsetModifier(int offset, Func<DateTimeOffset, int, DateTimeOffset> modifierFunction)
        {
            this.offset = offset;
            this.modifierFunction = modifierFunction;
        }

        public DateTimeOffset Before(DateTimeOffset originalDateTime)
        {
            return modifierFunction(originalDateTime, -1 * offset);
        }

        public DateTimeOffset Before(string originalDateTime)
        {
            return Before(DateTimeOffset.Parse(originalDateTime));
        }

        public DateTimeOffset After(DateTimeOffset originalDateTime)
        {
            return modifierFunction(originalDateTime, offset);
        }

        public DateTimeOffset After(string originalDateTime)
        {
            return After(DateTimeOffset.Parse(originalDateTime));
        }
    }
}