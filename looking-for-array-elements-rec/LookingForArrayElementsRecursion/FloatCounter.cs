using System;

namespace LookingForArrayElementsRecursion
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("RangeStart not equals rangeEnd");
            }

            if (CheackingArrayRangeOnError(rangeStart, rangeEnd, 0))
            {
                throw new ArgumentException("StartIndex more then endIndex");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            return SeachNumberInRange(arrayToSearch, rangeStart, rangeEnd, 0, arrayToSearch.Length, 0);
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("RangeStart not equals rangeEnd");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (arrayToSearch.Length == 0)
            {
                throw new ArgumentException("ArratToSearch is empty");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return SeachNumberInRange(arrayToSearch, rangeStart, rangeEnd, startIndex, startIndex + count, 0);
        }

        private static int SeachNumberInRange(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int numberIndex, int endNumberIndex, int indexRange)
        {
            if (numberIndex == endNumberIndex)
            {
                return 0;
            }
            else if (indexRange == rangeEnd.Length)
            {
                return SeachNumberInRange(arrayToSearch, rangeStart, rangeEnd, numberIndex + 1, endNumberIndex, 0);
            }
            else
            {
                if (arrayToSearch[numberIndex] >= rangeStart[indexRange] && arrayToSearch[numberIndex] <= rangeEnd[indexRange])
                {
                    return SeachNumberInRange(arrayToSearch, rangeStart, rangeEnd, numberIndex, endNumberIndex, indexRange + 1) + 1;
                }
                else
                {
                    return SeachNumberInRange(arrayToSearch, rangeStart, rangeEnd, numberIndex, endNumberIndex, indexRange + 1);
                }
            }
        }

        private static bool CheackingArrayRangeOnError(float[] start, float[] end, int index)
        {
            if (start.Length == index)
            {
                return false;
            }
            else if (start[index] > end[index])
            {
                return true;
            }
            else
            {
                return CheackingArrayRangeOnError(start, end, index + 1);
            }
        }
    }
}
