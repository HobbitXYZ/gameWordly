using System;

    class Program
    {
        //Пример слова, в будущем нужно будет сделать базу/найти словарь слов
        static char[] exampleWord = {'a', 'b', 'c', 'd', 'e'};

        // Поле
        static char[,] field = new char[6, 5]; 

        static void Main(string[] args)
        {
            makeField();
        }

        static void makeField()
        {
            for(int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    field[i,j] = '*';
                    System.Console.Write(field[i,j] + " ");
                }
            System.Console.WriteLine();
            }
        }

        

    }
