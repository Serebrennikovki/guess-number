using GuessNumber.Contracts;

namespace GuessNumber.Services;

public class GeneratorService : IGenerator
{
    public int GenerateNumber()
    {
        return new Random().Next(0,100);
    }
}