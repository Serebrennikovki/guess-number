using GuessNumber.Contracts;

namespace GuessNumber.Services;

public class MatchingService : IMatching
{
    public bool MatchingNumber(int wishedNumber, int guessNumber) => wishedNumber == guessNumber;
}