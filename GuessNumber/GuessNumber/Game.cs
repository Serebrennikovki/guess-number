using GuessNumber.Contracts;

namespace GuessNumber.Services;

public class Game
{
    
    private readonly IMatching _matchingService;
    private readonly IGenerator _generatorService;
    private readonly IInputOutput _inputOutputService;
    
    public Game(IMatching matchingService, IGenerator generatorService, IInputOutput inputOutputService)
    {
        _generatorService = generatorService;
        _inputOutputService = inputOutputService;
        _matchingService = matchingService;
    }

    public void Run()
    {
        _inputOutputService.WriteTitle();
        var guessNumber = _generatorService.GenerateNumber();

        while (true)
        {
            var inputNumber = _inputOutputService.ReadNumber();
            var isMaTching = _matchingService.MatchingNumber(guessNumber, inputNumber);
            _inputOutputService.WriteResult(isMaTching);
            if (isMaTching)
            {
                return;
            }
        }
    }
}