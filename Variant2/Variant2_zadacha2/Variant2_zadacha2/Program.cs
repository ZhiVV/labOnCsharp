using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant2_zadacha2
{
    class Program
    {
        // Даны числа А,С и В. Составить программу вывода значения квадратов меньшего и большего числа из заданных.

        static void Main(string[] args)
        {
            //Первое решение. простое, но длинное.
            {
                Console.WriteLine("Вариант решения №1");

                Console.Write("Введите число А, от -100 до 100: ");
                int a = GetInt();
                Console.Write("Введите число B, от -100 до 100: ");
                int b = GetInt();
                Console.Write("Введите число C, от -100 до 100: ");
                int c = GetInt();

                int max, min;

                if (a > b)
                {
                    max = a;
                    min = b;
                }
                else
                {
                    max = b;
                    min = a;
                }
                if (max > c)
                {
                    if (min > c)
                    {
                        min = c;
                    }                    
                }
                else
                {
                    max = c;
                }

                Console.WriteLine("Минимальное число {0} и его квадрат равен: {1}", min, min * min);
                Console.WriteLine("Максимальное число {0} и его квадрат равен: {1}", max, max * max);

                Console.WriteLine("Для продолжения работы программы нажмите любую клавишу");
                Console.WriteLine("");
                Console.ReadKey();

            }

            //Второе решение. с использованием операций Min и Max.
            {
                Console.WriteLine("Вариант решения №2");

                int[] array = new int[3];
                Console.Write("Введите число А, от -100 до 100: ");
                array[0] = GetInt();
                Console.Write("Введите число А, от -100 до 100: ");
                array[1] = GetInt();
                Console.Write("Введите число А, от -100 до 100: ");
                array[2] = GetInt();

                int min = array.Min();
                Console.WriteLine("Минимальное число {0} и его квадрат равен: {1}", min, min * min);
                int max = array.Max();
                Console.WriteLine("Максимальное число {0} и его квадрат равен: {1}", max, max * max);

                Console.Write("Для завершения работы программы нажмите любую клавишу");
                Console.ReadKey();
            }
        }
        //функция GetInt(), проверит что введено число от -100 до 100
        static int GetInt()
        {
            int newValue;
            string inputValue = Console.ReadLine();
            bool checkInputValue = int.TryParse(inputValue, out newValue);
            if (checkInputValue == true & newValue >= -100 & newValue <= 100)
            {
                return newValue;
            }
            else
            {
                Console.Write("Вы ввели не число или число меньше -100 либо больше 100, пожалуйста повторите ввод: ");
                return GetInt();
            }
        }

        }
    }

