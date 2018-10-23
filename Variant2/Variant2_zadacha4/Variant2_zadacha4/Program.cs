using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant2_zadacha4
{
    class Program
    {
        // Дана матрица вещественных чисел А (m x n). Построить матрицу В(n x m), транспонированную по отношению к А.
        static void Main(string[] args)
        {
            //Просим ввести размер матрицы, m и n
            Console.Write("Введите значение количества строк матрицы m, от 1 до 100: ");
            // ввод и проверка введенного числа вынесена в отдельную функцию GetInt
            int m = GetInt();
            Console.Write("Введите значение количества столбцов матрицы n, от 1 до 100: ");
            int n = GetInt();
            //инициализируем двумерный массив А размера m * n с типом данных  у элементов float (вещественные)
            double[,] matrixA = new double[m, n];

            //инициализируем двумерный массив В размера n * m с типом данных  у элементов float (вещественные)
            double[,] matrixB = new double[n, m];

            //генерируем матрицу А с помощью функции NewRandomArray
            matrixA = NewRandomArray(n, m);

            //отображаем матрицу А с помощью функции OutputArrayToConsole
            Console.WriteLine("Сгенерирована матрица А размера {0} на {1}:", m, n);
            OutputArrayToConsole(matrixA);

            Console.WriteLine("");
            //транспонируем матрицу А в матрицу В с помощью функции TranspMatrix
            matrixB = TranspMatrix(matrixA);

            //отображаем матрицу В с помощью функции
            Console.WriteLine("Транспонированная матрица В размера {0} на {1}:", n, m);
            OutputArrayToConsole(matrixB);

            // Задержка консоли
            Console.ReadKey();
        }

        // функция GetInt()  запрашивает текст для ввода, проверяет что введенный текст это число  от 1 до 100 (в условиях задачи ограничения в 100 не было, добавил в гуманистических целях) 
        // и возвращает введенное значение в место вызова. Есди введено неверное значение функция рекурсивно вызывает саму себя и просит повторить ввод.
    
        static int GetInt()
        {
            int newValue;            
            string inputValue = Console.ReadLine();
            bool checkInputValue = int.TryParse(inputValue, out newValue);
            if (checkInputValue == true & newValue > 0 & newValue <=100)
            {
                return newValue;
            }
            else
            {
                Console.Write("Вы ввели не число или число меньше 1 либо больше 100, пожалуйста повторите ввод: ");
                return GetInt();
            }
            
        }

        // функция TranspMatrix() создает новый массив, и присваивает его элементам значения исходного, меняя местами строки и столбцы       

        static double[,] TranspMatrix(double[,] matrix)
        {
            double[,] newMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[j, i] = matrix[i, j];
                }
            }            
            return newMatrix;
        }

        //функция NewRandomArray() для заполнения произвольного двумерного массива случайными вещественными значениями от -100 до 100 (данного ограничения так же нет в условии)
        // производится округление случайных чисел до 2-го знака после запятой для удобного вывода на экран.
        static double[,] NewRandomArray(int a, int b)
        {
            double[,] tempArray = new double[a, b];

            Random rnd = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    double d = rnd.NextDouble()*200 - 100;
                    tempArray[i, j] = Math.Round(d, 2);
                }
            }
            return tempArray;
        }

        //функция для вывода двумерного массива на экран в виде матрицы
        static void OutputArrayToConsole(double[,] tempArray)
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
