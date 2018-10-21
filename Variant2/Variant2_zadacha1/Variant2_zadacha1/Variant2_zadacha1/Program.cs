using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant2_zadacha1
{
    class Program
    {
        // Даны числа А,В,С и D. Составить программу вывода сумм квадратов всех троек этих чисел.
        static void Main(string[] args)
        {
            int[] array = new int [4];

            // Запрашиваем в цикле у пользователя значения каждого из 4-х чисел используя функцию GetInt
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите {0}-е число и нажмите клавишу Enter: ", i+1);
                array[i] = GetInt();
            }

            // В цикле выводим сумму квадратов всех элементов массива, поочередно присваивая каждому элементу массива значение 0
            for (int i = 0; i < array.Length; i++)
            {
                int temp = array[i];
                array[i] = 0;
                double sum = Math.Pow(array[0], 2) + Math.Pow(array[1], 2) + Math.Pow(array[2], 2) + Math.Pow(array[3], 2);
                Console.WriteLine("Сумма квадратов чисел без {0}-го числа, равна: {1}", i + 1, sum);
                array[i] = temp;
            }
            
            // Задержка Консоли
            Console.ReadKey();
        }

        // Функция для запроса данных и проверки введенных данных, если введено не целое число, то  выводится сообщение об ошибке и функция рекурсивно вызывает саму себя
        static int GetInt()
        {
            int newValue;
            string inputValue = Console.ReadLine();
            bool checkInputValue = int.TryParse(inputValue, out newValue);
            if (checkInputValue == true)
            {
                return newValue;
            }
            else
            {
                Console.Write("Вы ввели не число, повторите ввод:");
                return GetInt();
            }

        }

    }
}
