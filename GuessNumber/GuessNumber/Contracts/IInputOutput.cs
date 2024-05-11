namespace GuessNumber.Contracts;

public interface IInputOutput
{
    int ReadNumber();

    void WriteResult(bool isMatching);

    void WriteTitle();
}