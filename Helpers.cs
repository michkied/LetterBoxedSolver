namespace LetterBoxedSolver;

public class Helpers
{
    public static UInt64 GetLetterCode(char letter)
    {
        return 1ul << Config.AlphabetString.IndexOf(letter);
    }
    
    public static uint CountBits(UInt64 code)
    {
        uint count = 0;
        for (int i = 0; i < 64; i++)
        {
            if ((code >> i & 1) == 1) count++;
        }
        return count;
    }
}