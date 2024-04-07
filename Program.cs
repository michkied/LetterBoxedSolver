namespace LetterBoxedSolver;

class Program
{
    static void Main(string[] args)
    {
        var board = Ui.Init();
        var wordDictionary = Algorithms.MakeDictionary(board);
        Algorithms.Solve(board, wordDictionary);
    }
}