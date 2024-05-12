namespace GuessNumber.Contracts;

public interface IInputOutput
{
    int ReadNumber();

    void WriteMatchingResult(bool isMatching);

    void WriteWarning();

    void WriteTitle();
}