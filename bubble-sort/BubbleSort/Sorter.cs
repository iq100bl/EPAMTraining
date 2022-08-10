using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace BubbleSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with bubble sort algorithm.
        /// </summary>
        public static void BubbleSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 2 && array[0] > array[1])
            {
                (array[0], array[1]) = (array[1], array[0]);
            }

            if (array.Length >= 3)
            {
                int minIndex = 0;
                int maxIndex = array.Length - 1;
                for (int i = 1; maxIndex - minIndex > 1; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    }

                    if (i == maxIndex)
                    {
                        maxIndex--;
                        for (i = maxIndex - 1; i >= minIndex; i--)
                        {
                            if (array[i + 1] < array[i])
                            {
                                (array[i], array[i + 1]) = (array[i + 1], array[i]);
                            }
                        }

                        minIndex++;
                        i = minIndex;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive bubble sort algorithm.
        /// </summary>
        public static void RecursiveBubbleSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 2 && array[0] > array[1])
            {
                (array[0], array[1]) = (array[1], array[0]);
            }

            if (array.Length >= 3)
            {
                SortingLarge(array, 1, array.Length - 1, 0);
            }
        }

        private static void SortingLarge(this int[] array, int i, int maxIndex, int minIndex)
        {
            if (array[i - 1] > array[i])
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }

            if (maxIndex - minIndex > 1)
            {
                if (i < maxIndex)
                {
                    SortingLarge(array, i + 1, maxIndex, minIndex);
                }
                else
                {
                    SortingSmaller(array, i - 2, maxIndex - 1, minIndex);
                }
            }
        }

        private static void SortingSmaller(this int[] array, int i, int maxIndex, int minIndex)
        {
            if (array[i] > array[i + 1])
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }

            if (maxIndex - minIndex > 1)
            {
                if (i > minIndex)
                {
                    SortingSmaller(array, i - 1, maxIndex, minIndex);
                }
                else
                {
                    SortingLarge(array, i + 2, maxIndex, minIndex + 1);
                }
            }
        }
    }
}
