using System;

    class Program
    {
        static char[] exampleWord = {'a', 'b', 'c', 'd', 'e'}; //Пример слова, в будущем нужно будет сделать базу/найти словарь слов
        static char[,] field = new char[6, 5]; // Поле
        static char[] userWordChar; // Записанное слово пользователя по буквам
        static int attempt = 0; // попытка

        static void Main(string[] args)
        {
            makeField();

            
            while (attempt < 5)
            {
                attempt++;
                string userWord = Console.ReadLine();
                userWordChar = userWord.ToCharArray();
                checkBox();
            }

        }

        static void makeField()
        {
            System.Console.WriteLine("Game \"Wordly\" ");
            for(int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    field[i,j] = '*';
                    System.Console.Write(" " + field[i,j] + " ");
                }
            System.Console.WriteLine();
            }
        }
        static void checkBox() // Тут будет происходить проверка слова в нужной строке
        {
            for(int j = 0; j < field.GetLength(1); j++)
            {   
                field[attempt,j] = userWordChar[j];

                if(exampleWord[j] == userWordChar[j]) //В веденом слове буква НА ТОМ ЖЕ МЕСТЕ что и в загаданном 
                {
                    Console.BackgroundColor = ConsoleColor.Yellow; // Желтый - то же место
                    System.Console.Write(" " + field[attempt,j] + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }
                if(exampleWord.Intersect(userWordChar).Any()) //В веденом слове буква есть в загаданном 
                {
                    Console.BackgroundColor = ConsoleColor.Gray; // Серый - у буквы другое место
                    System.Console.Write(" " + field[attempt,j] + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else // Буквы нет
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    System.Console.Write(" " + field[1,j] + " ");
                    System.Console.WriteLine();
                    
                }
                

            }
        }

        

    }
