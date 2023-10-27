using System;
using System.IO;
using System.Linq;
using Buissnes;

namespace data
{
    public class GameState
    {
        static Biz biz = new Biz();
        string nikname = biz.GetNickname();
        public void ScoreTable()
        {
            Biz biz = new Biz();
            string nikname = biz.GetNickname();

            using (StreamWriter writer = new StreamWriter(@".\ScoreTable.txt", true))
            {
                if(nikname != null)
                writer.Write($",{nikname}");
                writer.Close();
            }
        }
        public void CountSqure() // Подсчитываем таблицу с результатами. Одно имя и есть один балл!
        {
            string fileContent = File.ReadAllText(@".\ScoreTable.txt"); // Откуда 
            string[] niknames = fileContent.Split(','); 
            Dictionary<string, int> stringCounts = new Dictionary<string, int>(); // Создаем словарь

            foreach (string nikname in niknames) 
            {
                if (stringCounts.ContainsKey(nikname)) // Проверяем, существует ли ник в словаре
                {
                    stringCounts[nikname]++; // Если да то ++ счетчик
                }
                else
                {
                    stringCounts[nikname] = 1; // Если нет то добавляем
                }
            }
            // Производим сортировку по убыванию угаданных слов
            var sortedStringCounts = stringCounts.OrderByDescending(str => str.Value).ToDictionary(str => str.Key, str => str.Value);

            foreach (var entry in sortedStringCounts) // Перебираем все элменеты
            {
                Console.WriteLine($"Никнейм: '{entry.Key}', Колиsчество угаданных слов: {entry.Value}");
            }  
        }
        public void SaveGame()
        {
            char[,] field = biz.GetField();
            string guessWordStr = biz.GetGuessWordStr();

            using (StreamWriter writer = new StreamWriter(@".\Save.txt"))
            {
                writer.Write($"{guessWordStr}");
                for(int i = 0; i < field.GetLength(1); i++)
                {
                    for(int j = 0; j < field.GetLength(0); j++)
                    {
                        writer.Write($"{field[j,i]}");
                    }
                }
            }
        }
        public void LoadGame()
        {
            string fileContent = File.ReadAllText(@".\SaveGame.txt"); // сохранение
            string allInfo = fileContent;

            int attempt = (allInfo.Count(c => c != '*') - 5) % 5;
            string exampleWord = 
        }
    }
}