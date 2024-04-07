using LetterBoxedSolver.Types;

namespace LetterBoxedSolver;

public static class Ui
{
    public static Board Init()
    {
        Console.WriteLine("Welcome to LetterBoxedSolver!\n");
        var (sides, lettersPerSide) = GatherBoardDimensions();
        return CreateBoard(sides, lettersPerSide);
    }

    private static Board CreateBoard(int sides, int lettersPerSide)
    {
        Board board = new();
        for (int i = 1; i <= sides; i++)
        {
            Console.WriteLine($"\nSide {i}");
            for (int j = 1; j <= lettersPerSide; j++)
            {
                Console.Write($"  Letter {j}: ");
                
                var response = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(response))
                {
                    j--;
                    continue;
                }
                char letter = response.ToUpper()[0];
                
                if (!Config.AlphabetString.Contains(letter))
                {
                    Console.WriteLine("    This character is not a valid letter!");
                    j--;
                    continue;
                }
                
                if (board.Letters.Contains(letter))
                {
                    Console.WriteLine("    This letter is already on the board!");
                    j--;
                    continue;
                }

                board.Add(letter, i);
            }
        }
        return board;
    }
    
    private static (int sides, int lettersPerSide) GatherBoardDimensions()
    {
        while (true)
        {
            Console.Write("Would you like to use default or custom board settings? (d/c): ");
            
            var response = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(response)) continue;
            var option = response.ToLower();
            
            if (option == "d") return (Config.DefNumberOfSides, Config.DefLettersPerSide);
            if (option == "c") break;
            
            Console.Write("Invalid input! ");
        }

        int sides = AskForPositiveInt("Number of board sides: ");
        int lettersPerSide = AskForPositiveInt("Number of letters per side: ");

        return (sides, lettersPerSide);
    }

    private static int AskForPositiveInt(string message)
    {
        int result;
        while (true)
        {
            Console.Write(message);
            string? response = Console.ReadLine();

            try
            {
                result = int.Parse(response!);
                if (result >= 1) return result;
            }
            catch (FormatException) {}
            
            Console.Write("Invalid input! ");
        }
    }
}