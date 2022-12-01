using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Frequncy { Weekly, Monthly, Yearly };


    class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine(
                "Язык программирования C#",
                Frequncy.Monthly,
                new DateTime(2022, 11, 22),
                22);

            Console.WriteLine(
           // Frequncy.Weekly.ToString() + ' ' +
           // Frequncy.Monthly.ToString() + '\n' +
           // Frequncy.Yearly.ToString() + "\n\n" +
            magazine.ToShortString() + "\n\n" +
            magazine.ToString() + "\n");

            magazine.AddArticles(
            new Article[2] {
                    new Article (
                        new Person("Basic", "User", new DateTime(2020, 12, 21)),
                        "Основы языка C#",
                        5.0
                    ),
                    new Article (
                        new Person("Advanced", "User", new DateTime(2021, 10, 14)),
                        "C# для продвинутых",
                        4.8
                    )
            }
        );
            Console.WriteLine(magazine.ToString() + '\n');


            int nrow, ncolumn;
            Console.WriteLine("Введите 2 числа массива: ");
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            nrow = Int32.Parse(input[0]);
            ncolumn = Int32.Parse(input[1]);

            Article[] first1 = new Article[nrow * ncolumn];
            for (int i = 0; i < nrow * ncolumn; i++)
                first1[i] = new Article();

            long start = Environment.TickCount;
            for (int i = 0; i < nrow * ncolumn; i++)
                first1[i].rating = 10;
            Console.WriteLine("Время выполнения одномерного массива: " + (Environment.TickCount - start) + " миллисекунд");

            Article[,] first2 = new Article[nrow, ncolumn];
            for (int i = 0; i < nrow; i++)
                for (int j = 0; j < ncolumn; j++)
                    first2[i, j] = new Article();

            start = Environment.TickCount;
            for (int i = 0; i < nrow; i++)
                for (int j = 0; j < ncolumn; j++)
                    first2[i, j].rating = 10;  
            Console.WriteLine("Время выполнения двумерного прямоугольного массива: " + (Environment.TickCount - start) + " миллисекунд");

            int s = 1, counter = nrow * ncolumn;
            while (counter > s)
            {
                counter -= s;
                s++;
            }

            Article[][] first3 = new Article[s][];
            for (int i = 0; i < s - 1; i++)
                first3[i] = new Article[i + 1];

            first3[s - 1] = new Article[counter];
            for (int i = 0; i < first3.Length; i++)
                for (int j = 0; j < first3[i].Length; j++)
                    first3[i][j] = new Article();
            start = Environment.TickCount;
            for (int i = 0; i < first3.Length; i++)
                for (int j = 0; j < first3[i].Length; j++)
                    first3[i][j].rating = 10;
            Console.WriteLine("Время выполнения двумерного ступенчатого массива: " + (Environment.TickCount - start) + " миллисекунд");
            Console.ReadLine();
        }
    }
}
