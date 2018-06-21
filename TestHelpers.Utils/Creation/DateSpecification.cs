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
}