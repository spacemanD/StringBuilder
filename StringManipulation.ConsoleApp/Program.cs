using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StringManipulation.Core.Interfaces;
using StringManipulation.Infrastructure.Context;
using StringManipulation.Infrastructure.Strategies;

namespace StringManipulation.ConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();
        var application = host.Services.GetRequiredService<Startup>();
        var add = host.Services.GetServices<IStringManipulationStrategy>().ToArray();

        await application.Start(add);
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services.AddTransient<IStringManipulationStrategy, ReverseWordsStrategy>()
                    .AddTransient<IStringManipulationStrategy, ReverseSentenceStrategy>()
                    .AddTransient<StringManipulationContext>()
                    .AddTransient<Startup>());
    }
}