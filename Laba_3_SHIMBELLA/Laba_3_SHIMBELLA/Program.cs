using Laba_3_SHIMBELLA;
using System;
using System.IO;
using System.Linq;

namespace Laba_3_SHIMBELLA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string path = string.Empty;
                while (true)
                {
                    Console.Write("Введите путь к файлу с матрицей (например, matrix.txt): ");
                    path = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Файл не найден или путь пуст. Попробуйте снова.");
                    }
                }

                try
                {
                    int[,] matrix = ReadMatrixFromFile(path);
                    var myMatrix = new MyMatrix(matrix);

                    int steps = 0;
                    while (true)
                    {
                        Console.Write("Введите количество шагов: ");
                        if (int.TryParse(Console.ReadLine(), out steps) && steps > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректное количество шагов. Введите положительное число.");
                        }
                    }


                    string mode = string.Empty;
                    while (true)
                    {
                        Console.Write("Искать кратчайшие (min) или длинейшие (max) пути? Введите 'min' или 'max': ");
                        mode = Console.ReadLine()?.Trim().ToLower();
                        if (mode == "min" || mode == "max")
                        {
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Режим указан некорректно. Попробуйте снова.");
                        }
                    }

                    if (mode == "min")
                        myMatrix.FindMinWay(steps);
                    else
                        myMatrix.FindMaxWay(steps);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении или обработке матрицы: {ex.Message}");
                }
            }
        }

        static int[,] ReadMatrixFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int rowCount = lines.Length;
            int colCount = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                var elements = lines[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (elements.Length != colCount)
                {
                    throw new Exception($"Ошибка: строка {i + 1} имеет {elements.Length} элементов, ожидалось {colCount}.");
                }

                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            return matrix;
        }
    }
}
