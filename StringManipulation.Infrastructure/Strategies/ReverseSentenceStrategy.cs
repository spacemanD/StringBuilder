using StringManipulation.Core.Interfaces;

namespace StringManipulation.Infrastructure.Strategies
{
    public class ReverseSentenceStrategy : IStringManipulationStrategy
    {
        public string ManipulateString(string input)
        {
            var chars = input.ToCharArray();
            Array.Reverse(chars);

            return new string(chars);
        }
    }
}
