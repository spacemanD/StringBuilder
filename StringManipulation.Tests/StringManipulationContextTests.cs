using StringManipulation.Core.Interfaces;
using StringManipulation.Infrastructure.Context;
using StringManipulation.Infrastructure.Strategies;
using Xunit;

namespace StringManipulation.Tests
{
    public class StringManipulationContextTests
    {
        [Theory]
        [InlineData("Hello World", "World Hello")] // Reverse Words
        [InlineData("abc def", "def abc")] // Reverse Words with multiple words
        [InlineData("123 456", "456 123")] // Reverse Words with numbers
        public void ManipulateString_ReverseWords_ShouldReturnCorrectResult(string input, string expectedOutput)
        {
            IStringManipulationStrategy strategy = new ReverseWordsStrategy();
            var context = new StringManipulationContext(strategy);
            var result = context.ManipulateString(input);
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("Hello World", "dlroW olleH")] // Reverse Sentence
        [InlineData("", "")] // Empty String
        [InlineData("123 456", "654 321")] // Reverse Words with numbers
        public void ManipulateString_ReverseSentence_ShouldReturnCorrectResult(string input, string expectedOutput)
        {
            IStringManipulationStrategy strategy = new ReverseSentenceStrategy();
            var context = new StringManipulationContext(strategy);
            var result = context.ManipulateString(input);
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void ManipulateString_WithNonNullStrategy_ShouldNotThrowException()
        {
            IStringManipulationStrategy strategy = new ReverseWordsStrategy();
            var context = new StringManipulationContext(strategy);
            Assert.NotNull(context.ManipulateString("Hello World"));
        }
    }
}