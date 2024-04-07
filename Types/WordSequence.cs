using System.Text;

namespace LetterBoxedSolver.Types;

public class WordSequence : IComparable<WordSequence>
{
    private List<string> _words = new();
    public string this[int index] => _words[index];
    
    public int Length => _words.Count;
    public char Start => _words[0][0];
    public char End => _words[^1][^1];

    public UInt64 Code { get; private set; }
    public uint Grade => Helpers.CountBits(Code);

    public WordSequence()
    {
        Code = 0;
    }

    public WordSequence(string word)
    {
        _words.Add(word);
        Code = 0;
        foreach (var letter in word)
        {
            Code |= Helpers.GetLetterCode(letter);
        }
    }
    
    public void Add(WordSequence sequence)
    {
        for (int i = 0; i < sequence.Length; i++)
        {
            _words.Add(sequence[i]);
        }
        Code |= sequence.Code;
    }
    
    public int CompareTo(WordSequence? w2)
    {
        return w2!.Grade.CompareTo(Grade);
    }
    
    public override string ToString()
    {
        if (_words.Count == 0) return "";
        
        var result = new StringBuilder();
        foreach (var word in _words)
        {
            result.Append($"-{word}");
        }
        result.Remove(0, 1);
        return result.ToString();
    }
}