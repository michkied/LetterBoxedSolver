namespace LetterBoxedSolver.Types;

public class Board
{
    private Dictionary<char, int> _data = new();
    
    public HashSet<char> Letters { get; } = new();
    public UInt64 BoardCode { get; private set; }
    public int GetSideIndex(char letter) => _data[letter];

    public void Add(char letter, int sideIndex)
    {
        _data.Add(letter,sideIndex);
        Letters.Add(letter);
        BoardCode |= Helpers.GetLetterCode(letter);
    }
}