using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace InsertionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with insertion sort algorithm.
        /// </summary>
        public static void InsertionSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 2 && array[0] > array[1])
            {
                (array[1], array[0]) = (array[0], array[1]);
            }
            else if (array.Length >= 3)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    for (int j = i; j > 0; j--)
                    {
                        if (array[j] < array[j - 1])
                        {
                            (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive insertion sort algorithm.
        /// </summary>
        public static void RecursiveInsertionSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 2 && array[0] > array[1])
            {
                (array[1], array[0]) = (array[0], array[1]);
            }
            else if (array.Length >= 3)
            {
                SortNumber(array, 1, 1);
            }
        }

        private static void SortNumber(this int[] array, int sortIndex, int sortSize)
        {
            if (sortIndex >= 1 && array[sortIndex] < array[sortIndex - 1])
            {
                (array[sortIndex], array[sortIndex - 1]) = (array[sortIndex - 1], array[sortIndex]);
                SortNumber(array, sortIndex - 1, sortSize);
            }

            if (sortSize < array.Length - 1)
            {
                sortSize++;
                SortNumber(array, sortSize, sortSize);
            }
        }
    }
}
