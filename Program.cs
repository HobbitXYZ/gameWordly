using System;
using System.Linq;
using System.ComponentModel;
using System.IO;
using Buissnes;

namespace Users
{
    class Program
    {
        static void Main(string[] args)
        { 
            Biz biz = new Biz();
            int action = 0;

            do
            {
                System.Console.Write("Выберите действие: \n" +
                "(0) Посмотреть таблицу результатов. \n" +
                "(1) Новая игра. \n" +
                "(2) Продолжить игру. \n" +
                "Выш выбор - ");
                action = int.Parse(Console.ReadLine());

                switch(action)
                {
                    case 0:
                    break;

                    case 1:
                    biz.guessWord();
                    biz.User();
                    break;

                    case 3:
                    break;
                }   
            }
            while (action > 3);   
        } 
    }
}