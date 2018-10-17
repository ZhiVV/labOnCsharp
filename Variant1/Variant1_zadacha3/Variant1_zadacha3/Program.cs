﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant1_zadacha3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Дана последовательность А из 50 чисел и число В.
             * Составить программу вывода чисел последовательности в следующем порядке:
             * вначале числа меньшие, чем В, а затем - остальные.             
             */

            //была идея сделать массив размером в 51 элемент, первые 50 заполняются случайными значениями, 51 вводится как В
            //затем сортировка пузырьком и просто выводятся все элементы по порядку, но посчитал что такой вариант не совсем удовлетворяет условиям задачи
            //т.к. нарушится последовательность чисел + сортировка потребует больше времени.

            //Объявляем массив с типом данных у элементов int, инициализируем его, указав размер в 50 элементов
            int[] array = new int[50];
                        
            Random rnd = new Random();
            //записываем в цикле случайные значения в массив 
            Console.WriteLine("50 случайных чисел от 1 до 1000 были записаны в одномерный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 1001);
                Console.Write("{0}", array[i]);
                if (i != 49)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            //Запрашиваем ввод числа В и сохраняем его в переменную, предварительно переведя из типа строка в число.
            Console.Write("Введите значение числа В и нажмите Enter: ");
            int b = Convert.ToInt32(Console.ReadLine());

            //в цикле проходим по всем элементам массива и если значение меньше числа В то выводим его на экран
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < b) Console.Write(array[i] + ", ");
            }
            //Выводим число В
            Console.Write(b + ", ");
            //в цикле проходим по всем элементам массива и выводим только те, которые равны или больше числа В
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= b) Console.Write(array[i] + ", "); //про лишнюю запятую в конце вывода знаю, но что бы было красиво без нее надо много доп.условий прописывать.
            }

            //Задержка консоли
            Console.Write("\nДля завершения работы программы нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
