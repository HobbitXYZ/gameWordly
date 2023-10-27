using System;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Buissnes

    {
        public class KeyboardInterrupt : System.Exception { } 
        class Biz
        {
            static string nikname;
            static bool save = false;
            static int score = 0;
            static char[] exampleWord = {' ', ' ', ' ', ' ', ' '}; //Пример слова, в будущем нужно будет сделать базу/найти словарь слов
            static char[,] field = new char[5, 6]; // Поле
            static char[] userWordChar = {' ', ' ', ' ', ' ', ' '}; // Записанное слово пользователя по буквам
            static int attempt = 0; // попытка
            static int win = 0; //Проверка на победу

            static void makeField() // Печать пустого поля
            {
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
            public void guessWord() // Выбор загадываемого слова
            {            
                string fileContent = File.ReadAllText(@".\Dictionary.txt"); // словарь
                string[] words = fileContent.Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                Random random = new Random();
                int randomIndex = random.Next(0, words.Length);

                string guessWordStr = words[randomIndex];
                exampleWord = guessWordStr.ToCharArray();  
            }
            static void CheckBox() // Присвоение буквы и Проверка буквы
            {
                for (int i = 0; i < field.GetLength(1); i++ )
                {
                    for(int j = 0; j < field.GetLength(0); j++ )
                    {
                        field[j,attempt] = userWordChar[j]; // Вытащил из рудимента старого checkBox() присвоение элемента

                        if(field[j,i] == exampleWord[j]) //В веденом слове буква НА ТОМ ЖЕ МЕСТЕ что и в загаданном 
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow; // Желтый - то же место
                            Console.ForegroundColor = ConsoleColor.Black;
                            System.Console.Write(" " + field[j,i] + " ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        if (exampleWord.Contains(field[j,i])) //Буква в веденом слове буква есть в загаданном 
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray; // Серый - у буквы другое место
                            System.Console.Write(" " + field[j,i] + " ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else // Буквы нет
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            System.Console.Write(" " + field[j,i] + " ");                       
                        }
                    }
                    System.Console.WriteLine();
                }
            }  
            static void validity() // Проверка на ввод
            {
                bool isValidInput = false;
                string userWord; 
                            
                do
                {
                    isValidInput = true; // Чтобы зайти в цикл
                    System.Console.Write("Введите слово: ");
                    System.Console.WriteLine();

                    ConsoleKeyInfo[] word = new ConsoleKeyInfo[5];
                    for (int i = 0; i < 5; i++)
                    {
                        word[i] = Console.ReadKey();
                        if (word[i].Key == ConsoleKey.Backspace)
                        {
                            i -= 2;
                            continue;
                        }
                        if (i > 0 && word[i].Modifiers == ConsoleModifiers.Control && word[i].Key == ConsoleKey.S)
                        {
                            throw new KeyboardInterrupt();
                        }   
                    }
                    StringBuilder wordBuilder = new(5);
                    foreach(var key in word)
                    {
                        wordBuilder.Append(key.KeyChar);
                    }
                    userWord = wordBuilder.ToString().ToUpper();

                    userWordChar = userWord.ToCharArray();
                    
                    if (userWord.Length == 5)
                    {
                        // Проверяем каждый символ в строке на то, что он является буквой
                        foreach(char c in userWordChar)
                        {
                            if (!char.IsLetter(c))
                            {
                                isValidInput = false; // Если найден не-буквенный символ, считаем ввод некорректным
                                break; // а нам одного достаточно АХАХХАХАХАХХА D;
                            }
                        }
                        Console.BackgroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Введено некорректное слово. Пожалуйста, введите слово из 5 букв.");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Введено некорректное слово. Пожалуйста, введите слово из 5 букв.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        isValidInput = false;
                    }
                }
                while(!isValidInput);
            }
            public void User() // Условие победы
            {
                try
                {
                    do
                    {
                        System.Console.Write("Введите ник - ");
                        nikname = Console.ReadLine();
                    } 
                    while (string.IsNullOrEmpty(nikname));

                    Console.Clear();
                    System.Console.Write($"Ваш никнейм - {nikname}\n Игра \"5 букв\" \n");
                    
                    makeField();

                    while (attempt < 6)
                    {  
                        validity();

                        Console.Clear();

                        CheckBox();
                    
                        win = 0;
                        for(int i = 0; i < field.GetLength(0); i++)
                        {   
                            if(exampleWord[i] == userWordChar[i])
                            win++;
                        }
                        if(win >= 5) // победа
                        {
                            Console.Clear();
                            CheckBox();
                            score++;
                            System.Console.WriteLine("Ты победил!");
                            break;
                        }
                        if(attempt == 5) // проигрыш
                        {
                            Console.Clear();
                            CheckBox();
                            nikname = null;
                            System.Console.WriteLine("Ты проиграл!");
                        }
                        
                        attempt++;
                    } 
                    attempt = 0;
                }
                catch(KeyboardInterrupt) // Прерывание Сохранение работы программы
                {
                Console.Clear();
                System.Console.WriteLine("Вы завершили вашу работу. Все данные сохранены!");
                
                
                }
            } 
            public string GetNickname()
            {
                return nikname;
            }
            public char[,] GetField()
            {
                return field;
            }
        }  
    }