using System;
using System.IO;
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
                writer.WriteLine($"{nikname},{score}");
                writer.Close();
            }
        }
        public void SqureAmmount()
        {
            
        }
    }
}