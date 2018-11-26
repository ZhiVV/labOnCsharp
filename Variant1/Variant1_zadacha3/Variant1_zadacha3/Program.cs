using System;
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

                //запись случайных значений в элементы массива была вынесена в отдельную функцию NewRandomArray
            array = NewRandomArray(50);                               
                //Вывод элементов массива на экран так же был вынесен в отдельную функцию                                
            Console.WriteLine("50 случайных чисел от 1 до 1000 были записаны в одномерный массив:");
            OutputArrayToConsole(array);
                //Запрашиваем ввод числа В и сохраняем его в переменную, предварительно переведя из типа строка в число.
            Console.Write("Введите значение числа В и нажмите Enter: ");
                // преобразование из строки в число меняем на отдельный метод GetInt() с проверкой введенных данных 
            int b = GetInt();

                // Передаем переменную б и массив в функцию, которая проводит её сравнение с элементами массива и выводит их на экран
            CompareNumToArray(b, array);
            
                //Задержка консоли
            Console.Write("\nДля завершения работы программы нажмите любую клавишу");
            Console.ReadKey();
        }

        // Данная функция запрашивает текст для ввода, проверяет что введенный текст это число
        // и возвращает введенное значение в место вызова. Если введено неверное значение функция рекурсивно вызывает саму себя и просит повторить ввод.
        // Так же первоначальный метод Convert.ToInt32() используемый для преобразования строки в целое число, был заменен на TryParse() который в случае ошибки преобразования не выдаст exсeption который нужно будет обработать отдельно

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
                Console.Write("Вы ввели не число, пожалуйста повторите ввод:");
                return GetInt();
            }
        }

        // Данный метод принимает на вход число, создает массив указанного размера. В цикле записывает в его элементы случайные значения от 1 до 1000
        // И возвращает получившийся массив обратно в место вызова

        static int[] NewRandomArray(int sizeArray)
        {
            int[] tempArray = new int[sizeArray];
            Random rnd = new Random();
            
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = rnd.Next(1, 1001);
            }
            return tempArray;
        }

        // данный метод выводит на экран в одну строку переданный одномерный массив чисел
        static void OutputArrayToConsole(int[] tempArray)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                Console.Write("{0}", tempArray[i]);
                if (i != 49)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            return;
        }

        // данная функция делает следующее: в цикле проходит по всем элементам массива и если значение меньше числа В то выводит его на экран
        // потом выводит число В, потом опять в цикле проходит по всем элементам массива и выводит только те, которые равны или больше числа В

        static void CompareNumToArray(int tempNum, int[] tempArray)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] < tempNum) Console.Write(tempArray[i] + ", ");
            }

            Console.Write(tempNum + ", ");

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] >= tempNum) Console.Write(tempArray[i] + ", "); //про лишнюю запятую в конце вывода знаю, но что бы было красиво без нее надо много доп.условий прописывать.
            }
        }

    }
}
