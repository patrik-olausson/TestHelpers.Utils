using System;

namespace TestHelpers.Utils
{
    public class DateBuilder
    {
        private int offset;

        public DateBuilder(int offset)
        {
            this.offset = offset;
        }

        public DateTimeOffsetModifier Days => new DateTimeOffsetModifier(this.offset, (x,i) => x.AddDays(i));
        public DateTimeOffsetModifier Years => new DateTimeOffsetModifier(this.offset, (x,i) => x.AddYears(i));
        public DateTimeOffsetModifier Months => new DateTimeOffsetModifier(this.offset, (x,i) => x.AddMonths(i));
        public DateTimeOffsetModifier Weeks => new DateTimeOffsetModifier(this.offset * 7, (x,i) => x.AddDays(i));
        
    }

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
