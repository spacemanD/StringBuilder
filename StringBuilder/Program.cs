using Microsoft.Extensions.DependencyInjection;
using System;

// Define the strategy interface
interface IStringManipulationStrategy
{
    string ManipulateString(string input);
}

// Concrete strategy for reversing the order of words
class ReverseWordsStrategy : IStringManipulationStrategy
{
    public string ManipulateString(string input)
    {
        string[] words = input.Split(' ');
        Array.Reverse(words);
        return string.Join(' ', words);
    }
}

// Concrete strategy for reversing the entire sentence
class ReverseSentenceStrategy : IStringManipulationStrategy
{
    public string ManipulateString(string input)
    {
        char[] chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}

// Context class that uses the selected strategy
class StringManipulationContext
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

class Program
{
    static void Main()
    {
        // Setup DI container
        var serviceProvider = new ServiceCollection()
            .AddTransient<IStringManipulationStrategy, ReverseWordsStrategy>()
            .AddTransient<IStringManipulationStrategy, ReverseSentenceStrategy>()
            .AddTransient<StringManipulationContext>()
            .BuildServiceProvider();

        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        // Display menu
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Reverse the order of words in a sentence");
        Console.WriteLine("2. Display the sentence in reverse order");

        // Get user choice
        int choice = int.Parse(Console.ReadLine());

        // Resolve the strategy based on user choice
        IStringManipulationStrategy strategy = choice switch
        {
            1 => serviceProvider.GetRequiredService<ReverseWordsStrategy>(),
            2 => serviceProvider.GetRequiredService<ReverseSentenceStrategy>(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        // Instantiate the context with the resolved strategy
        var context = new StringManipulationContext(strategy);

        // Perform string manipulation using the selected strategy
        string result = context.ManipulateString(input);

        // Display the result
        Console.WriteLine("Result:");
        Console.WriteLine(result);
    }
}
