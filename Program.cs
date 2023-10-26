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
            System.Console.WriteLine("Выберите действие: \n" +
                "(0) Посмотреть таблицу результатов. \n" +
                "(1) Новая игра. \n" +
                "(2) Продолжить игру. \n" +
                "Выш выбор - "
                );
            

            Biz biz = new Biz();
            biz.guessWord();
            biz.User();
        } 
    }
}