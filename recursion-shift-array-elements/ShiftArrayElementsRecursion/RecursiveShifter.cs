using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations == null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            CountingIterations(source, iterations, 0);
            return source;
        }

        private static void CountingIterations(int[] source, int[] iterations, int index)
        {
            if (index < iterations.Length)
            {
                if (iterations[index] == 0) 
                {
                    index++;
                }
                else if (index % 2 == 1)
                {
                    ShiftToRight(source);
                    iterations[index]--;
                }
                else
                {
                    ShiftToLeft(source);
                    iterations[index]--;
                }

                CountingIterations(source, iterations, index);
            }         
        }

        // I wanted to use this metods from RecursiveEnumShifter, but tests throw an error at internal access
        private static void ShiftToRight(int[] source)
        {
            var rightElement = source[^1];
            Array.Copy(source[..^1], 0, source, 1, source.Length - 1);
            source[0] = rightElement;
        }

        private static void ShiftToLeft(int[] source)
        {
            var leftElement = source[0];
            Array.Copy(source[1..], source, source.Length - 1);
            source[^1] = leftElement;
        }
    }
}
