using Microsoft.Extensions.Configuration;

namespace GuessNumber.Services;

public class FloatNumberGeneratorService : GeneratorService
{
    private readonly IConfiguration _configuration;
    
    public FloatNumberGeneratorService(IConfiguration configuration) : base(configuration)
    {
    }

    public float GenerateFloatNumber()
    {
        double range = (double) float.MaxValue - (double) float.MinValue;
        double sample = new Random().NextDouble();
        return (float) (sample * range) + float.MinValue;
    }
}