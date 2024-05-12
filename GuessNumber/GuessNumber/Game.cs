using GuessNumber.Contracts;
using Microsoft.Extensions.Configuration;

namespace GuessNumber.Services;

public class Game
{
    
    private readonly IMatching _matchingService;
    private readonly IGenerator _generatorService;
    private readonly IInputOutput _inputOutputService;
    private readonly IConfiguration _configuration;
    
    public Game(IMatching matchingService, IGenerator generatorService, IInputOutput inputOutputService,IConfiguration configuration)
    {
        _generatorService = generatorService;
        _inputOutputService = inputOutputService;
        _configuration = configuration;
        _matchingService = matchingService;
    }

    public void Run()
    {
        _inputOutputService.WriteTitle();
        var guessNumber = _generatorService.GenerateNumber();
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