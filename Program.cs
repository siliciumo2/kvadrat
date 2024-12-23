using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Random random = new Random();
        Console.WriteLine("Введите количество элементов (от 1 до  10000):");

        if (!int.TryParse(Console.ReadLine(), out int numberOfElements) || numberOfElements < 1 || numberOfElements > 10000)
        {
            Console.WriteLine("Количество элементов должно быть от 1 до 10000.");
            return;
        }

        int[] array = new int[numberOfElements];
        for (int i = 0; i < numberOfElements; i++)
        {
            array[i] = random.Next(1, 101);
        }

        int maxSumOfSquares = FindMaxSumOfSquares(array);

        Console.WriteLine($"Максимальная сумма квадратов = {maxSumOfSquares}");
    }

    static int FindMaxSumOfSquares(int[] array)
    {
        int maxSum = 0;
        for (int i = 0; i < array.Length - 10; i++)
        {
            int squareOfCurrent = array[i] * array[i];

            for (int j = i + 10; j < array.Length; j++)
            {
                int squareOfNext = array[j] * array[j];
                int currentSum = squareOfCurrent + squareOfNext;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        return maxSum;
    }
}