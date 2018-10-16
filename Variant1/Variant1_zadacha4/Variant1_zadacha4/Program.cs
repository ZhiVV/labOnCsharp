using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant1_zadacha4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *Дана целочисленная матрица А (m * n). Определить сумму
             * Максимальных элементов каждого столбца матрицы.
            */

            //Просим ввести размер матрицы, m и n
            Console.Write("Введите значение количества строк матрицы m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите значение количества столбцов матрицы n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            //инициализируем двумерный массив размера m * n
            int[,] array = new int[m, n];

            Random rnd = new Random();
            //записываем в цикле случайные значения в массив и сразу выводим в виде таблицы на экран
            Console.WriteLine("{0} случайных чисел от 1 до 100 были записаны в двумерный массив:", m * n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i,j] = rnd.Next(1, 101);
                    Console.Write("{0,8}", array[i,j]);                                     
                }
                Console.WriteLine();
            }

            //Находим в каждом столбце элемент с максимальным значением и выводим их сумму
            int sum = 0;
            int temp;
            for (int i = 0; i < n; i++)
            {                
                temp = 0;
                for (int j = 0; j < m; j++)
                {
                    if (array[j, i] > temp) temp = array[j, i];
                }
                sum = sum + temp;
            }

            Console.WriteLine("Сумма максимальных значений из каждого столбца равна: " + sum);

            //Задержка консоли
            Console.Write("Для завершения работы программы нажмите любую клавишу");
            Console.ReadKey();


        }
    }
}
