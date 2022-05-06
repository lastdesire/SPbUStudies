using System;

namespace FloydAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин в графе:");
            var n = Int32.Parse(Console.ReadLine());
            var matrix = new double[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.WriteLine(
                        $"Введите расстояние между вершинами {i + 1} и {j + 1}. Если они соединены ребром, то введите расстояние. Если они НЕ соединены ребром, то введите NO. Если вершина одна и та же, то введите 0:");
                    var answer = Console.ReadLine();
                    if (double.TryParse(answer, out var doubleAnswer))
                    {
                        matrix[i, j] = doubleAnswer;
                    }
                    else
                    {
                        matrix[i, j] = double.PositiveInfinity;
                    }
                }
            }
            Console.WriteLine("Ответ:");
            for (var k = 0; k < n; k++)
            {
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < n; j++)
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + matrix[k, j]);
                    }
                }
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}