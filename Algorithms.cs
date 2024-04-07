using LetterBoxedSolver.Types;

namespace LetterBoxedSolver;

public static class Algorithms
{
    public static Dictionary<char, List<WordSequence>> MakeDictionary(Board board)
    {
        Dictionary<char, List<WordSequence>> dictionary = new();
        foreach (var letter in board.Letters)
        {
            dictionary.Add(letter, new List<WordSequence>());
        }
        
        using (var file = new StreamReader(Config.DictionaryFilePath))
        {
            while (true)
            {
                string? line = file.ReadLine();
                if (line == null) break;
                if (line.Length < Config.MinWordLength) continue;
                
                line = line.ToUpper();
                if (!IsWordCorrect(line, board)) continue;
                var word = new WordSequence(line);
                dictionary[word.Start].Add(word);
            }
        }

        foreach (var letter in dictionary.Keys)
        {
            dictionary[letter].Sort();
        }

        return dictionary;
    }

    private static bool IsWordCorrect(string word, Board board)
    {
        for (int i = 0; i < word.Length-1; i++)
        {
            if (!board.Letters.Contains(word[i])) return false;
            if (!board.Letters.Contains(word[i+1])) return false;
            if (board.GetSideIndex(word[i]) == board.GetSideIndex(word[i+1])) return false;
        }
        
        return true;
    }
    
    public static void Solve(Board board, Dictionary<char, List<WordSequence>> wDict)
    {
        Dictionary<char, List<WordSequence>> sequencesA = new();
        Dictionary<char, List<WordSequence>> sequencesB = new();
        foreach (char letter in board.Letters)
        {
            sequencesA.Add(letter, new List<WordSequence>());
            sequencesB.Add(letter, new List<WordSequence>());
            sequencesA[letter].Add(new WordSequence());
        }

        var oldSeq = sequencesA;
        var newSeq = sequencesB;
        
        for (int maxWordCount = 1;; maxWordCount++)
        {
            Console.Write($"\nLooking for {maxWordCount}-word combinations... ");
            bool found = false;
            foreach (char letter in board.Letters)
            {
                List<WordSequence> newList = new(); 
                foreach (var word in wDict[letter])
                {
                    foreach (var prevSequence in oldSeq[word.End])
                    {
                        var sequence = new WordSequence(word.ToString());
                        sequence.Add(prevSequence);
                        if (sequence.Code == board.BoardCode)
                        {
                            if (!found) Console.Write("Found!\n");
                            found = true;
                            Console.Write($"    {sequence}");
                            Console.ReadLine();
                        }
                        newList.Add(sequence);
                    }
                }
                newSeq[letter] = newList;
            }
            
            (oldSeq, newSeq) = (newSeq, oldSeq);
            foreach (char letter in board.Letters)
            {
                newSeq[letter].Clear();
            }
            if (!found) Console.Write("Not found.");
        }
    }
}