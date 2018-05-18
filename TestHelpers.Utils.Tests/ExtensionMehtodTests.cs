using TestHelpers.Utils;
using Xunit;

namespace ExtensionMehtodTests
{
    public class ReplaceAllMatches
    {
        [Fact]
        public void GivenAValueThatHasOneOccuranceOfTheValueToReplace_ThenItReplacesTheValueAsExpected()
        {
            var value = "Some text";

            var result = value.ReplaceAllMatches("text", "fun!");

            Assert.Equal("Some fun!", result);
        }

        [Fact]
        public void GivenAValueThatHasTwoOccurancesOfTheValueToReplace_ThenItReplacesBothValuesAsExpected()
        {
            var value = "Some text with a word and a word";

            var result = value.ReplaceAllMatches("word", "loud WORD");

            Assert.Equal("Some text with a loud WORD and a loud WORD", result);
        }

        [Fact]
        public void GivenAValueThatHasNoOccurancesOfTheValueToReplace_ThenItRetrunsTheOriginalValue()
        {
            var value = "Some text that shouldn't change";

            var result = value.ReplaceAllMatches("Unknown");

            Assert.Equal("Some text that shouldn't change", result);
        }

        [Fact]
        public void GivenAValueThatHasTwoMatchesUsingARegularExpression_ThenItReplacesBothValuesAsExpected()
        {
            var value = "Cat, Hat, Bat";

            var result = value.ReplaceAllMatches("[CB]at", "Replaced");

            Assert.Equal("Replaced, Hat, Replaced", result);
        }
    }
}
