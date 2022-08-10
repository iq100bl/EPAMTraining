using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with quick sort algorithm.
        /// </summary>
        public static void QuickSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 2 && array[0] > array[1])
            {
                (array[0], array[1]) = (array[1], array[0]);
            }

            if (array.Length > 2)
            {
                int startIndex = 0;
                int endIndex = array.Length - 1;
                int leftIndex;
                int rightIndex;
                int pivot;
                int[] pivots = new int[array.Length];
                while (array.Length - 1 > startIndex)
                {
                    leftIndex = startIndex;
                    rightIndex = endIndex;
                    pivot = (leftIndex + rightIndex) / 2;
                    while (leftIndex < pivot)
                    {
                        if (array[leftIndex] >= array[pivot])
                        {
                            if (rightIndex <= pivot)
                            {
                                (array[leftIndex], array[pivot], array[pivot - 1]) = (array[pivot - 1], array[leftIndex], array[pivot]);
                                pivot--;
                            }
                            else
                            {
                                while (pivot < rightIndex)
                                {
                                    if (array[pivot] > array[rightIndex])
                                    {
                                        (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
                                        rightIndex--;
                                        break;
                                    }

                                    rightIndex--;
                                }

                                leftIndex++;
                            }
                        }
                        else
                        {
                            leftIndex++;
                        }
                    }

                    if (pivot < rightIndex)
                    {
                        while (pivot < rightIndex)
                        {
                            if (array[pivot] > array[rightIndex])
                            {
                                (array[rightIndex], array[pivot], array[pivot + 1]) = (array[pivot + 1], array[rightIndex], array[pivot]);
                            }
                            else
                            {
                                rightIndex--;
                            }
                        }
                    }

                    if (pivot - startIndex < 2)
                    {
                        if (array[pivot] < array[startIndex])
                        {
                            (array[pivot], array[startIndex]) = (array[startIndex], array[pivot]);
                        }

                        startIndex = pivot + 1;
                        endIndex = array.Length - 1;
                        for (int i = 0; i < pivots.Length - 1; i++)
                        {
                            if (startIndex < pivots[i] && endIndex > pivots[i])
                            {
                                endIndex = pivots[i];
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < pivots.Length - 1; i++)
                        {
                            if (pivots[i] == default)
                            {
                                pivots[i] = pivot;
                                break;
                            }
                        }

                        endIndex = pivot;
                        for (int i = 0; i < pivots.Length - 1; i++)
                        {
                            if (startIndex < pivots[i] && endIndex > pivots[i])
                            {
                                endIndex = pivots[i];
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive quick sort algorithm.
        /// </summary>
        public static void RecursiveQuickSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 2 && array[0] > array[1])
            {
                (array[0], array[1]) = (array[1], array[0]);
            }

            if (array.Length > 2)
            {
                SplitArray(array, 0, array.Length - 1);
            }
        }

        private static void SplitArray(this int[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivot = SwapElements(array, startIndex, endIndex, (startIndex + endIndex) / 2);
                if (pivot > 1)
                {
                    SplitArray(array, startIndex, pivot - 1);
                }

                if (endIndex - pivot > 1)
                {
                    SplitArray(array, pivot + 1, endIndex);
                }
            }
        }

        private static int SwapElements(this int[] array, int leftIndex, int rightIndex, int pivot)
        {
            if (leftIndex > -1)
            {
                leftIndex = GetIndexHighestNumberOnLeft(array, leftIndex, pivot);
                if (leftIndex > -1)
                {
                    if (rightIndex < array.Length)
                    {
                        rightIndex = GetIndexSmallestNumberOnRight(array, rightIndex, pivot);
                        if (rightIndex < array.Length)
                        {
                            (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
                            return SwapElements(array, leftIndex, rightIndex, pivot);
                        }
                        else if (pivot - leftIndex == 1)
                        {
                            (array[pivot], array[leftIndex]) = (array[leftIndex], array[pivot]);
                            pivot--;
                            return pivot;
                        }
                        else
                        {
                            (array[leftIndex], array[pivot], array[pivot - 1]) = (array[pivot], array[pivot - 1], array[leftIndex]);
                            pivot--;
                            return SwapElements(array, leftIndex, rightIndex, pivot);
                        }
                    }
                    else if (pivot - leftIndex == 1)
                    {
                        (array[pivot], array[leftIndex]) = (array[leftIndex], array[pivot]);
                        pivot--;
                        return pivot;
                    }
                    else
                    {
                        (array[leftIndex], array[pivot], array[pivot - 1]) = (array[pivot], array[pivot - 1], array[leftIndex]);
                        pivot++;
                        return SwapElements(array, leftIndex, rightIndex, pivot);
                    }
                }
                else
                {
                    return SwapElements(array, leftIndex, rightIndex, pivot);
                }
            }
            else if (rightIndex < array.Length)
            {
                rightIndex = GetIndexSmallestNumberOnRight(array, rightIndex, pivot);
                if (rightIndex < array.Length)
                {
                    if (rightIndex - pivot == 1)
                    {
                        (array[pivot], array[rightIndex]) = (array[rightIndex], array[pivot]);
                        pivot++;
                        return pivot;
                    }
                    else
                    {
                        (array[rightIndex], array[pivot], array[pivot + 1]) = (array[pivot], array[pivot + 1], array[rightIndex]);
                        pivot++;
                        return SwapElements(array, leftIndex, rightIndex, pivot);
                    }
                }
                else
                {
                    return pivot;
                }
            }
            else
            {
                return pivot;
            }
        }

        private static int GetIndexHighestNumberOnLeft(this int[] array, int leftIndex, int pivot)
        {
            if (leftIndex < pivot)
            {
                if (array[leftIndex] >= array[pivot])
                {
                    return leftIndex;
                }
                else
                {
                    return GetIndexHighestNumberOnLeft(array, leftIndex + 1, pivot);
                }
            }
            else
            {
                return -1;
            }
        }

        private static int GetIndexSmallestNumberOnRight(this int[] array, int rightIndex, int pivot)
        {
            if (rightIndex > pivot)
            {
                if (array[rightIndex] < array[pivot])
                {
                    return rightIndex;
                }
                else
                {
                    return GetIndexSmallestNumberOnRight(array, rightIndex - 1, pivot);
                }
            }
            else
            {
                return array.Length;
            }
        }
    }
}
