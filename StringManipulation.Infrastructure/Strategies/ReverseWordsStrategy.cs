using StringManipulation.Core.Interfaces;

namespace StringManipulation.Infrastructure.Strategies
{
    public class ReverseWordsStrategy : IStringManipulationStrategy
    {
        public string ManipulateString(string input)
        {
            var words = input.Split(' '); 
            Array.Reverse(words);

            return string.Join(' ', words);
        }
    }
}
