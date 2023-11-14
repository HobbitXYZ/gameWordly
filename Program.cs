using System;
using System.Linq;
using System.ComponentModel;
using System.IO;
using Buissnes;
using data;

namespace Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Buissnes.Buissnes biz = new Buissnes.Buissnes();
            Basa gm = new Basa();
            int action = 0;

            while (action != 3)
            {
                System.Console.Write("Выберите действие: \n" +
                "(0) Посмотреть таблицу результатов. \n" +
                "(1) Новая игра. \n" +
                "(2) Продолжить игру. \n" +
                "(3) Выйти. \n" +
                "Выш выбор - ");

                if(int.TryParse(Console.ReadLine(), out action))
                {
                    switch(action)
                    {
                        case 0:
                        Console.Clear();
                        gm.CountSqure();
                        System.Console.Write("Нажмите Enter чтобы выйти ");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 1:
                        Console.Clear();
                        biz.guessWord();
                        biz.User();
                        
                        System.Console.Write("Нажмите Enter чтобы выйти ");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 2:
                        biz.GL();
                        System.Console.Write("Нажмите Enter чтобы выйти ");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 3:
                        break;

                        default:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Некорректный ввод, попробуйте снова.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    }
                }
            }    
        } 
    }
}