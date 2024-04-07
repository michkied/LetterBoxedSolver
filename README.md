# LetterBoxedSolver
A simple solver for the [New York Times "Letter Boxed" puzzle](https://www.nytimes.com/puzzles/letter-boxed).

### Usage
The program is a console application. In the default configuration, it will ask for three letters for each of the four sides of the puzzle board. The order of letters on a single side does not matter, neither does the order of the sides. However, it is important not to mix the letters between the sides.  
A custom configuration is also available, allowing the user to pick the number of sides and the number of letters per side.

### Dictionary
To work properly, the program requires a dictionary of words in a form of a line-separated text file. The dictionary file should be placed in the same directory as the program and named `dictionary.txt`. Alternatively, it's possible to specify a different dictionary path in the `Config.cs` file.  
The dictionary file in this repository is a list of English words without any special characters or spaces. Source: [dwyl/english-words](https://github.com/dwyl/english-words?tab=readme-ov-file)
