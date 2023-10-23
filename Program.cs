using System;
using System.ComponentModel;
using System.Linq;

    class Program
    {
        static char[] exampleWord = {'a', 'b', 'c', 'd', 'e'}; //Пример слова, в будущем нужно будет сделать базу/найти словарь слов
        static char[,] field = new char[5, 6]; // Поле
        static char[] userWordChar = {' ', ' ', ' ', ' ', ' '}; // Записанное слово пользователя по буквам
        static int attempt = 0; // попытка
        static int win = 0; //Проверка на победу

        static void Main(string[] args)
        {
            makeField();

            while (attempt < 6)
            {
                string userWord = Console.ReadLine();
                if (userWord != null)
                {
                    userWordChar = userWord.ToCharArray();
                }

                checkBox();
                winOrLose();
                attempt++;
            }  
        }

        static void makeField()
        {
            System.Console.WriteLine("Game \"Wordly\" ");
            for(int i = 0; i < field.GetLength(1); i++)
            {
                for(int j = 0; j < field.GetLength(0); j++)
                {
                    field[j,i] = '*'; // Инвертирование индексов для правильной работы с массивом
                    System.Console.Write(" " + field[j,i] + " "); // Инвертирование индексов для правильной работы с массивом
                }
            System.Console.WriteLine();
            }
        }
        static void checkBox() // Тут будет происходить проверка слова в нужной строке
        {
            for(int j = 0; j < field.GetLength(0); j++)
            {   
                field[j,attempt] = userWordChar[j];
                
                if(userWordChar[j] == exampleWord[j]) //В веденом слове буква НА ТОМ ЖЕ МЕСТЕ что и в загаданном 
                {
                    Console.BackgroundColor = ConsoleColor.Yellow; // Желтый - то же место
                    System.Console.Write(" " + field[j,attempt] + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }
                if (exampleWord.Contains(userWordChar[j])) //Буква в веденом слове буква есть в загаданном 
                {
                    Console.BackgroundColor = ConsoleColor.Gray; // Серый - у буквы другое место
                    System.Console.Write(" " + field[j,attempt] + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else // Буквы нет
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    System.Console.Write(" " + field[j,attempt] + " ");
                                        
                }
            }
        }
        static void printField()
        {
            for (int i = 0; i < field.GetLength(1); i++ )
            {
                for(int j = 0; j < field.GetLength(0); j++ )
                {
                    System.Console.Write(" " + field[j,i] + " ");                        
                }
                System.Console.WriteLine();
            }
        }  
        static void winOrLose()
        {

            System.Console.WriteLine(win);
            if(win >= 4)
            {
                System.Console.WriteLine("\nYou win");
            
            }
            if(attempt == 5)
            {
                System.Console.WriteLine("\n");
                printField();
                System.Console.WriteLine("Ты проиграл");
            }
        }  
    }
    
