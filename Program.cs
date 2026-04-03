class Program
{
    static void Main()
    {
        Console.WriteLine($"Привет! Поиграем в игру \"Виселица\", вводи слова через пробел, я выберу случайное и ты будешь угадывать слово!\nУ тебя 10 попыток");

        string inputWords = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(inputWords)) { Console.WriteLine("Введите хотя-бы 1 слово"); return; }
        string[] words = inputWords.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Console.Clear();
        List<char> list = new List<char>();

        Random rnd = new Random();
        int score = 1;

        string selectedWord = words[rnd.Next(0, words.Length)].ToUpper();

        int maxAttempts = selectedWord.Length + 2;
        Console.WriteLine($"Я загадал слово.");

        char[] field = new char[selectedWord.Length];
        for (int i = 0; i < field.Length; i++)
            field[i] = '_';

        while(true)
        {
            if (score > maxAttempts)
            {
                Console.WriteLine("Ты проиграл");
                break;
            }

            foreach (char c in field) { Console.Write(c + " "); }
            Console.WriteLine($"\nУгадай букву.\tТвои попытки: {score}");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;
            char suggest = char.ToUpper(input[0]);


            if(list.Contains(suggest))
            {
                Console.WriteLine("Ты уже вводил эту букву, попробуй еще раз!");
                score--;
                continue;
            }
            else list.Add(suggest);

            if (selectedWord.Contains(suggest))
            {
                for (int i = 0; i < field.Length; i++)
                {
                    if (selectedWord[i] == suggest) field[i] = suggest;
                }
                Console.WriteLine($"Ты угадал букву {suggest}");
            }
            else
            {
                Console.WriteLine($"Не угадал! Пробуй еще!");
            }

            if(!field.Contains('_'))
            {
                Console.WriteLine($"Победа! Это было слово {selectedWord}");
                PrintGameStatus(score, list, selectedWord);
                break;
            }
            score++;
            Console.Clear();
        }
    }

    static void PrintGameStatus(int score, List<char> list, string word)
    {
        Console.Clear();
        Console.WriteLine($"Ты прошел игру со счётом {score}. Загаданное слово - {word}");
        Console.WriteLine($"Также ты использовал буквы: ");
        foreach (char c in list) Console.Write(c + " ");
    }
}