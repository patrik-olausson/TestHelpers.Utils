using FluentAssertions;
using System;
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

    public class AsDate
    {
        [Theory]
        [InlineData("2018-07-01", "2018-07-01")]
        [InlineData("2018-07-01 12:00", "2018-07-01")]
        [InlineData("2018/07/01", "2018-07-01")]
        public void GivenAStringRepresentationOfDate_ThenADateTimeOffsetInstanceIsReturned(string input, string expectedParsedOutput)
        {
            var parsedDate = input.AsDate();

            var resultInSpecificFormat = parsedDate.ToString("yyyy-MM-dd");

            resultInSpecificFormat.Should().BeEquivalentTo(expectedParsedOutput);
        }

        [Theory]
        [InlineData("notadate")]
        public void GivenAnInvalidStringRepresentationOfDate_ThenAnExceptionIsThrownWithExamplesOfValidStrings(string input)
        {
            var exception = Assert.Throws<FormatException>(() => input.AsDate());

            exception.Message.Should().Be($"{input} is not a valid date. Supported date formats include yyyy-MM-dd, yyyy-MM-dd HH:mm:ss, yyyy/MM/dd.");
        }
    }
}