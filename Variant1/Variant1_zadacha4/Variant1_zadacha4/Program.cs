using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant1_zadacha4
{
    class Program
    {
        // Данная функция запрашивает текст для ввода, проверяет что введенный текст это число  от 1 до 1000 (в условиях задачи ограничения в 1000 не было, добавил в гуманистических целях 
        // и возвращает введенное значение в место вызова. Есди введено неверное значение функция рекурсивно вызывает саму себя и просит повторить ввод.
        // Так же первоначальный метод Convert.ToInt32() используемый для преобразования строки в целое число, был заменен на TryParse() который в случае ошибки преобразования не выдаст exсeption который нужно будет обработать отдельно
        
        static int GetInt ()
        {
            int newValue;

            string inputValue = Console.ReadLine();           
            bool inputCheck = int.TryParse(inputValue, out newValue);
            
            if (inputCheck == true & newValue > 0 & newValue <= 1000)
            {                
                return newValue;
            }
            else
            {
                Console.Write("Вы ввели не число или число меньше 1 либо больше 1000, пожалуйста повторите ввод:");
                return GetInt();
            }            
        }

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
