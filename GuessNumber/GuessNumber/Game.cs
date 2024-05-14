using GuessNumber.Contracts;
using Microsoft.Extensions.Configuration;

namespace GuessNumber.Services;

public class Game
{
    
    private readonly IMatching _matchingService;
    private readonly IGenerator _generatorService;
    private readonly IInputOutput _inputOutputService;
    private readonly IConfiguration _configuration;
    private readonly FloatNumberGeneratorService _floatGenerator;
    
    public Game(IMatching matchingService, IGenerator generatorService, IInputOutput inputOutputService,IConfiguration configuration,
        FloatNumberGeneratorService floatGenerator)
    {
        _generatorService = generatorService;
        _inputOutputService = inputOutputService;
        _configuration = configuration;
        _matchingService = matchingService;
        _floatGenerator = floatGenerator;
    }

    public void Run()
    {
        _inputOutputService.WriteTitle();
        var guessNumber = _floatGenerator.GenerateNumber();
        var attempsAmount = int.Parse(_configuration["Game:Attemps"]);
        int currentAttemps = 0;
        do
        {
            currentAttemps++;
            var inputNumber = _inputOutputService.ReadNumber();
            var isMaTching = _matchingService.MatchingNumber(guessNumber, inputNumber);
            _inputOutputService.WriteMatchingResult(isMaTching);
            if (isMaTching)
            {
                return;
            }
        } while (currentAttemps < attempsAmount);
        
        _inputOutputService.WriteWarning();
    }
}