using StringManipulation.Core.Interfaces;
using StringManipulation.Infrastructure.Context;
using StringManipulation.Infrastructure.Strategies;

namespace StringManipulation.ConsoleApp
{
    internal class Startup
    {
        public async Task Start(IStringManipulationStrategy[] strategies)
        {
            Console.WriteLine("Enter a sentence:");
            var input = Console.ReadLine() ?? string.Empty;

            // Display menu
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Reverse the order of words in a sentence");
            Console.WriteLine("2. Display the sentence in reverse order");

            // Get user choice
            if (!int.TryParse(Console.ReadLine(), out var choice) || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            // Resolve the strategy based on user choice
            var strategy = choice switch
            {
                1 => strategies.First(x => x is ReverseWordsStrategy),
                2 => strategies.First(x => x is ReverseSentenceStrategy),
                _ => throw new InvalidOperationException("Invalid choice")
            };

            // Instantiate the context with the resolved strategy
            var context = new StringManipulationContext(strategy);

            // Perform string manipulation using the selected strategy
            var result = await Task.Factory.StartNew(() => context.ManipulateString(input));

            // Display the result
            Console.WriteLine("Result:");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
