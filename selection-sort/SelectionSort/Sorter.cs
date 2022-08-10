using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace SelectionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with selection sort algorithm.
        /// </summary>
        public static void SelectionSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int min = 0;
            int max = array.Length - 1;
            if (array.Length <= 1)
            {
                return;
            }

            if (array.Length == 2)
            {
                if (array[0] > array[1])
                {
                    var x = array[0];
                    array[0] = array[1];
                    array[1] = x;
                }
            }
            else
            {
                do
                {
                    int minNumber = int.MaxValue;
                    int minIndexNumber = min;
                    int maxNumber = int.MinValue;
                    int maxIndexNumber = max;
                    for (int i = min; i <= max; i++)
                    {
                        if (array[i] < minNumber)
                        {
                            minNumber = array[i];
                            minIndexNumber = i;
                        }

                        if (array[i] > maxNumber)
                        {
                            maxNumber = array[i];
                            maxIndexNumber = i;
                        }
                    }

                    if (maxIndexNumber == min && minIndexNumber == max)
                    {
                        array[min] = minNumber;
                        array[max] = maxNumber;
                    }

                    if (minIndexNumber == max)
                    {
                        array[minIndexNumber] = array[min];
                        array[min] = minNumber;
                        array[maxIndexNumber] = array[max];
                        array[max] = maxNumber;
                    }
                    else
                    {
                        array[maxIndexNumber] = array[max];
                        array[max] = maxNumber;
                        array[minIndexNumber] = array[min];
                        array[min] = minNumber;
                    }

                    max--;
                    min++;
                }
                while (max - min > 1);
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive selection sort algorithm.
        /// </summary>
        public static void RecursiveSelectionSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            RecursiveSelectionSort(array, 0, array.Length - 1, 0);
        }

        private static void RecursiveSelectionSort(this int[] array, int minStep, int maxStep, int count)
        {
            if (maxStep <= 0)
            {
                count++;
                if (count < (array.Length - 1) / 2)
                {
                    RecursiveSelectionSort(array, count, array.Length - 1 - count, count);
                }
            }
            else
            {
                if (array[minStep] > array[minStep + 1])
                {
                    int x = array[minStep];
                    array[minStep] = array[minStep + 1];
                    array[minStep + 1] = x;
                }

                if (array[maxStep] < array[maxStep - 1])
                {
                    int x = array[maxStep];
                    array[maxStep] = array[maxStep - 1];
                    array[maxStep - 1] = x;
                }

                RecursiveSelectionSort(array, minStep + 1, maxStep - 1, count);
            }
        }
    }
}
