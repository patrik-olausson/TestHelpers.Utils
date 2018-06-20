using FluentAssertions;
using TestHelpers.Utils;
using Xunit;

namespace CreateATests
{
    public class SetOf
    {
        [Fact]
        public void GivenTwoItems_ReturnsCollectionOfItems()
        {
            var set = Create.A.SetOf("Foo", "Bar");

            set.Should().BeEquivalentTo("Foo", "Bar");
        }

        [Fact]
        public void GivenNoItems_ReturnsEmptyCollection()
        {
            var set = Create.A.SetOf<string>();

            set.Should().BeEmpty();
        }
    }
}
