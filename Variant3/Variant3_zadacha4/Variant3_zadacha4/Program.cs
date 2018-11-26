using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Variant3_zadacha4
{
    class Program
    {
        // Дана целочисленная матрица чисел А (m x n). Сформировать одномерный массив В (n), элементы
        // которого равны сумме положительных чисел соответствующих столбцов матрицы А.
        // Доработки:
        // Массив А читается из файла input_array.csv и массив В записывается в файл output_array.csv.
        // Если входной файл не найден, то выводится сообщение и программа завершается.
        // Если вместо цифр во входном файле будут буквы или цифры вне диапазона [-100, 100] то данному элементу массива будет присвоено значение 0
        // файлы должны располагаться в каталоге с исполняемым файлом или при запуске из студии в 
        // ..Variant3\Variant3_zadacha4\Variant3_zadacha4\bin\Debug

        static void Main(string[] args)
        {
            {
                string readPath = "input_array.csv";
								
				if (!System.IO.File.Exists(readPath))
				{
				    Console.WriteLine("Файл {0} не найден", readPath);
					goto ExitProgram;
				}

				// здесь нужно было бы как то применить using (как для записи в файл) но не  получилось передать получившийся arrText дальше
				// поэтому входной файл продолжает быть открытым до конца работы программы
				StreamReader objReader = new StreamReader(readPath);                
                string sLine = "";
                List<string> arrText = new List<string>();

                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    arrText.Add(sLine);
                    
                }
								
				// Определяем количество "столбцов" и "строк" во входном файле массива соответствующего размера
				string[] tempString = arrText[0].Split(',');
                int n = tempString.Length;
                int m = arrText.Count;

				// создаем массив и заполняем его соответствующими значениями из файла
                int[,] arrayA = new int[m, n];
                for (int i = 0; i < m; i++)
                {
                    tempString = arrText[i].Split(',');
					// Проверка на одинаковое количество элементов в строках файла, если разное то шаг с переводом элементов строки в числа пропускается,
					// и данные элементы массива arrayA остаются со значениями по умолчанию, то есть 0.
					if (n!= tempString.Length)
					{
						Console.WriteLine("Количество элементов в строке {0} не соответствует первой строке. Всем её элементам будет присвоено значение 0.", i+1);
						continue;
					}
                    for (int j = 0; j < n; j++)
                    {						
                    arrayA[i,j] = GetInt(tempString[j]);
                    }
                    
                }

				// отображаем матрицу А с помощью функции OutputArray2dimToConsole
				Console.WriteLine();
				Console.WriteLine("На основе данных из файла сгенерирована матрица А размера {0} на {1}:", m, n);
                OutputArray2dimToConsole(arrayA);

                int[] arrayB = new int[n];

                // делаем одномерный массив В (n), элементы которого равны сумме положительных чисел соответствующих столбцов матрицы А.
                arrayB = TransformArrayFrom2dimTo1dim(arrayA);
				Console.WriteLine();
				Console.WriteLine("матрица А была преобразована в одномерную матрицу В, элементы которой, равны сумме положительных чисел соответствующих столбцов матрицы А:");
				OutputArray1dimToConsole(arrayB);


                // записываем массив В в файл				                
                string writePath = "output_array.csv";
                                
                using (StreamWriter sw = new StreamWriter(writePath, false))
                {
                    sw.WriteLine(String.Join(", ", arrayB));
                }

			ExitProgram:
				Console.WriteLine();				
				Console.Write("Для завершения работы программы, нажмите любую клавишу.");
                Console.ReadKey();
            }			            
            
        }
        // функция TransformArrayFrom2dimTo1dim()  формирует одномерный массив В (n), элементы которого равны 
        // сумме положительных чисел соответствующих столбцов матрицы А.

        static int[] TransformArrayFrom2dimTo1dim(int[,] tempArray)
        {
            int[] newArray = new int[tempArray.GetLength(1)];
            for (int j = 0; j < tempArray.GetLength(1); j++)
            {
                for (int i = 0; i < tempArray.GetLength(0); i++)
                {
                    newArray[j] += (tempArray[i, j] > 0) ? tempArray[i, j] : 0;
                }
            }

            return newArray;
        }
                     
        // функция GetInt(), проверяет что текст разделенный запятыми является цифрами из диапазона [-100, 100], 
        // если нет то данному элементу присваивается значение 0
        static int GetInt(string readValue)
        {
            int newValue;
            bool checkReadValue = int.TryParse(readValue, out newValue);
            if (checkReadValue == true & newValue > -101 & newValue < 101)
            {
                return newValue;
            }
            else
            {
                Console.WriteLine("В файле найдено не число или число не из диапазона [-100, 100]. Оно было заменено на 0");
                newValue = 0;
                return newValue;
            }
        }
        //функция для вывода одномерного массива на экран в виде строки
        static void OutputArray1dimToConsole(int[] tempArray)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                Console.Write("{0,8}", tempArray[i]);                
            }
            Console.WriteLine();
        }

        //функция для вывода двумерного массива на экран в виде матрицы
        static void OutputArray2dimToConsole(int[,] tempArray)
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
   
