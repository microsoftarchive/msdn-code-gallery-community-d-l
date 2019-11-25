using System;

namespace QuickSortRecursive
{
    class Program
    {
        /// <summary>
        ///   Exemple of the QuickSort
        /// </summary>
        /// <remarks> Is a sorting method based on the concept of the Division and achievement and also in trade (as in order "bubble sort").</remarks>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] numbers = { 5, 8, 9, 6, 3, 2, 1, 5, 4 };
 
            Console.WriteLine("QuickSort By Recursive Method");

            QuickSort_Recursive(numbers, 0, numbers.Length - 1);

            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbers[i]);

            Console.ReadLine();
        }

        static public void QuickSort_Recursive(int[] arr, int first, int last)
        {

            int down, high, middle, pivot, repository;
            down = first;
            high = last;
            middle = (int)((down + high) / 2);

            pivot = arr[middle];

            while (down <= high)
            {
                while (arr[down] < pivot)
                    down++;
                while (arr[high] > pivot)
                    high--;
                if (down < high)
                {
                    repository = arr[down];
                    arr[down++] = arr[high];
                    arr[high--] = repository;
                }
                else
                {
                    if (down == high)
                    {
                        down++;
                        high--;
                    }
                }
            }

            if (high > first)
                QuickSort_Recursive(arr, first, high);
            if (down < last)
                QuickSort_Recursive(arr, down, last);        
        }

    }
}