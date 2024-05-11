using GuessNumber.Contracts;

namespace GuessNumber.Services;

public class InputOutputService : IInputOutput
{
    private const string Title = "Угадай число!";
    private const string SuccessText = "Вы угадали! Игра завершена";
    private const string WrongText = "Вы не угадали, попробуйте еще раз...";
    
    public int ReadNumber()
    {
        var line = Console.ReadLine();
        int cifra;
        if (!Int32.TryParse(line, out cifra))
        {
            throw new Exception();
        }
        return cifra;
    }

    public void WriteResult(bool isMatching)
    {
        var text = isMatching ? SuccessText : WrongText;
        Console.WriteLine(text);
    }

    public void WriteTitle()
    {
        Console.WriteLine(Title);
    }
}