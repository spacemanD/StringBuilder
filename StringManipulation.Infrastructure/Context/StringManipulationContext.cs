using StringManipulation.Core.Interfaces;

namespace StringManipulation.Infrastructure.Context
{
    public class StringManipulationContext : IStringManipulationContext
    {
        private readonly IStringManipulationStrategy _strategy;

        public StringManipulationContext(IStringManipulationStrategy strategy)
        {
            _strategy = strategy;
        }

        public string ManipulateString(string input)
        {
            return _strategy.ManipulateString(input);
        }
    }
}
