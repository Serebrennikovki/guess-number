using GuessNumber.Contracts;
using Microsoft.Extensions.Configuration;

namespace GuessNumber.Services;

public class GeneratorService : IGenerator
{
    private readonly IConfiguration _configuration;
    public GeneratorService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public int GenerateNumber()
    {
        var tresholdFrom = int.Parse(_configuration["Game:GeneratorThreshold:From"]);
        var tresholdTo = int.Parse(_configuration["Game:GeneratorThreshold:To"]);
        return new Random().Next(tresholdFrom,tresholdTo);
    }
}