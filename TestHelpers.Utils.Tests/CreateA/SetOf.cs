using FluentAssertions;
using TestHelpers.Utils;
using Xunit;

namespace CreateATests
{
    public class SetOf
    {
        [Fact]
        public void GivenTwoItems_ThenACollectionOfItemsIsReturned()
        {
            var set = Create.A.SetOf("Foo", "Bar");

            set.Should().BeEquivalentTo("Foo", "Bar");
        }

        [Fact]
        public void GivenNoItems_ThenAnEmptyCollectionIsReturned()
        {
            var set = Create.A.SetOf<string>();

            set.Should().BeEmpty();
        }
    }
}