// See https://aka.ms/new-console-template for more information

using GuessNumber.Contracts;
using GuessNumber.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuessNumber;

public class Program
{
   
    static void Main(string[] args)
    {
        var config = AddConfiguration();
        var host = CreateHostBuilder(args, config).Build();
        host.Services.GetRequiredService<Game>().Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<Game>();
                services.AddSingleton<IConfiguration>(_ => configuration);
                services.AddTransient<IGenerator, GeneratorService>();
                services.AddTransient<IMatching, MatchingService>();
                services.AddTransient<IInputOutput, InputOutputService>();
                services.AddTransient<FloatNumberGeneratorService>();
            });
    }

    private static IConfiguration AddConfiguration()
    {
       return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
    }
}