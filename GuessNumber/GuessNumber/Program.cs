// See https://aka.ms/new-console-template for more information

using GuessNumber.Contracts;
using GuessNumber.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuessNumber;

public class Program
{
   
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Services.GetRequiredService<Game>().Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<Game>();
                services.AddTransient<IGenerator, GeneratorService>();
                services.AddTransient<IMatching, MatchingService>();
                services.AddTransient<IInputOutput, InputOutputService>();
            });
    }
}