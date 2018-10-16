using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant1_zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Вариант 1. Задача 1.    
            Даны числа А,В,С и D. Составить программу вывода сумм всех пар этих чисел (А+В, А+С, ...).
            */

            //Первое решение. простое, но длинное.
            {
                Console.WriteLine(" Вариант решения №1");
                //объявляю переменные типа int, но можно было бы использовать sbyte или short.
                int A = 0, B = 0, C = 0, D = 0;

                //Выводим поясняющую надпись и считываем введенное значение в переменную А, преобразовав тип string в int
                Console.Write("Введите целочисленное значение переменной A и нажмите клавишу Enter: ");
                A = Convert.ToInt32(Console.ReadLine());
                //  Все то же самое для В
                Console.Write("Введите целочисленное значение переменной B и нажмите клавишу Enter: ");
                B = Convert.ToInt32(Console.ReadLine());
                //  Все то же самое для С
                Console.Write("Введите целочисленное значение переменной C и нажмите клавишу Enter: ");
                C = Convert.ToInt32(Console.ReadLine());
                //  Все то же самое для D
                Console.Write("Введите целочисленное значение переменной D и нажмите клавишу Enter: ");
                D = Convert.ToInt32(Console.ReadLine());

                // строка разделитель
                Console.WriteLine();
                
                //Выводим сумму А и В 
                Console.WriteLine("Сумма чисел А и В равна: {0}", A + B);
                //Выводим сумму А и C 
                Console.WriteLine("Сумма чисел А и C равна: {0}", A + C);
                //Выводим сумму А и D 
                Console.WriteLine("Сумма чисел А и D равна: {0}", A + D);
                //Выводим сумму B и C 
                Console.WriteLine("Сумма чисел B и C равна: {0}", B + C);
                //Выводим сумму B и D 
                Console.WriteLine("Сумма чисел B и D равна: {0}", B + D);
                //Выводим сумму C и D 
                Console.WriteLine("Сумма чисел C и D равна: {0}", C + D);

                //Задержка консоли
                Console.WriteLine("Для продолжения работы программы нажмите любую клавишу");
                Console.ReadKey();

            }

            //Второе решение. С циклами и массивами.
            {
                Console.WriteLine("Вариант решения №2");
                //Объявляем массив с именем numbers типа int, инициализируем его (всем элементам присвается значение по умолчанию 0) и задаем его длину.
                int[] numbers = new int[4];
                //Объявляем массив с именем names типа string, для хранения "имен" чисел. Сразу указав значение элементов 
                //Вместо двух массивов, возможно удобнее было бы использовать какой то вид коллекций отличный от массивов, но еще не разбирался с ними
                //или сделать двумерный массив 2 * 4 типа string, но для финального сложения требовалось бы преобразование каждого элемента первой строки из string в int
                string[] names = new string[4] {"A", "B", "C", "D"};
                // в цикле for записываем введенные пользователем цифры в массив numbers, преобразовав тип string в int
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"Введите целочисленное значение переменной {names[i]} и нажмите клавишу Enter: ");
                    numbers[i] = Convert.ToInt32(Console.ReadLine());                    
                }
                // во вложенном цикле начинаем складывать каждый элемент массива попарно со следующими и выводить сумму на экран
                for (int i = 0; i + 1 < numbers.Length; i++)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        Console.WriteLine($"Сумма чисел {names[i]} и {names[j]} равна: {numbers[i] + numbers[j]}");
                    }
                }

                //Задержка консоли
                Console.WriteLine("Для завершения работы программы нажмите любую клавишу");
                Console.ReadKey();
            }
        }
    }
}
