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
            int score = biz.GetScore();


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
            Dictionary<string, int> stringCounts = new Dictionary<string, int>();

            foreach(string nik in niknames)
            {
                stringCounts[nik] = 1;
            }

            int uniqueNicknames = stringCounts.Keys.Count;

            foreach (var entry in stringCounts)
            {
                Console.WriteLine($"Никнейм: '{entry.Key}', Количество угаданных слов: {entry.Value}");
            }
            
        }
    }
}