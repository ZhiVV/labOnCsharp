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
            Console.Write("Введите значение количества строк матрицы m, от 1 до 100: ");
            // ввод и проверка введенного числа вынесена в отдельную функцию GetInt
            int m = GetInt();
            Console.Write("Введите значение количества столбцов матрицы n, от 1 до 100: ");
            int n = GetInt();
            //инициализируем двумерный массив размера m * n
            int[,] array = new int[m, n];

            //заполнение элементов массива случайными значениями вынесено в отдельную функцию NewRandomArray
            array = NewRandomArray(m, n);

            Console.WriteLine("{0} случайных чисел от 1 до 100 были записаны в двумерный массив:", m * n);
            //вывод двумерного массивыа на экран вынесен в отдельную процедуру OutputArratoConsole
            OutputArrayToConsole(array);

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

        // Данная функция запрашивает текст для ввода, проверяет что введенный текст это число  от 1 до 1000 (в условиях задачи ограничения в 1000 не было, добавил в гуманистических целях 
        // и возвращает введенное значение в место вызова. Есди введено неверное значение функция рекурсивно вызывает саму себя и просит повторить ввод.
        // Так же первоначальный метод Convert.ToInt32() используемый для преобразования строки в целое число, был заменен на TryParse() который в случае ошибки преобразования не выдаст exсeption который нужно будет обработать отдельно

        static int GetInt()
        {
            int newValue;

            string inputValue = Console.ReadLine();
            bool checkInputValue = int.TryParse(inputValue, out newValue);

            if (checkInputValue == true & newValue > 0 & newValue <= 1000)
            {
                return newValue;
            }
            else
            {
                Console.Write("Вы ввели не число или число меньше 1 либо больше 1000, пожалуйста повторите ввод:");
                return GetInt();
            }
        }

        //функция для заполнения произвольного двумерного массива случайными значениями от 1 до 100
        static int[,] NewRandomArray(int a, int b)
        {
            int[,] tempArray = new int[a, b];

            Random rnd = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    tempArray[i, j] = rnd.Next(1, 101);
                }
            }
            return tempArray;
        }

        //функция для вывода двумерного массива на экран в виде матрицы
        static void OutputArrayToConsole(int[,] tempArray)
        {
            for (int i = 0; i < tempArray.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray.GetLength(1); j++)
                {
                    Console.Write("{0,8}", tempArray[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
