using System;

namespace FindMaximumTask
{
    /// <summary>
    /// Class for operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Finds the element of the array with the maximum value recursively.
        /// </summary>
        /// <param name="array"> Source array. </param>
        /// <returns>The element of the array with the maximum value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        private static int maxNumber;

        public static int FindMaximum(int[] array)
        {
            if (array == null) 
            { 
                throw new ArgumentNullException(nameof(array)); 
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Ну ексепшен и эксепшен, чё бухтеть то");
            }

            maxNumber = int.MinValue;
            FindMaximumRecursion(array);
            return maxNumber;
        }
        
        private static void FindMaximumRecursion(int[] array)
        {
            if (array.Length == 1)
            {
               if (maxNumber < array[0])
                {
                    maxNumber = array[0];
                }
            }
            else
            {
                FindMaximumRecursion(array[.. (array.Length / 2)]);
                FindMaximumRecursion(array[(array.Length / 2) ..]);
            }
        }
    }
}
