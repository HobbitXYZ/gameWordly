using System;
using System.IO;
using System.Linq;
using Buissnes;

namespace data
{
    public class GameState
    {
        public void ScoreTable()
        {
            Biz biz = new Biz();
            string nikname = biz.GetNickname();

            using (StreamWriter writer = new StreamWriter(@".\ScoreTable.txt", true))
            {
                writer.Write($",{nikname}");
                writer.Close();
            }
        }
        public void CountSqure() // Подчитываем таблицу с результатами. Одно имя и есть один балл!
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

            foreach (var entry in stringCounts) // Перебираем все элменеты
            {
                Console.WriteLine($"Никнейм: '{entry.Key}', Колиsчество угаданных слов: {entry.Value}");
            }
            
        }
    }
}