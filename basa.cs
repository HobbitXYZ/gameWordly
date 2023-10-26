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

            using (StreamWriter writer = new StreamWriter(@".\ScoreTable.txt"))
            {
                writer.WriteLine(nikname);
            }
        }
    }
}