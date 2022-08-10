using System;

#pragma warning disable S2368

namespace LookingForArrayElementsRecursion
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (CheackingArrayRangeOnError(ranges, 0))
            {
                throw new ArgumentException("Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.");
            }

            return SeachNumberInRange(arrayToSearch, ranges, 0, arrayToSearch.Length, 0);
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (CheackingArrayRangeOnError(ranges, 0))
            {
                throw new ArgumentException("Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.");
            }

            if (startIndex < 0 || startIndex >= arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || count + startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return SeachNumberInRange(arrayToSearch, ranges, startIndex, startIndex + count, 0);
        }

        private static int SeachNumberInRange(decimal[] arrayToSearch, decimal[][] ranges, int numberIndex, int endNumberIndex, int indexRange)
        {
            if (numberIndex == endNumberIndex)
            {
                return 0;
            }
            else if (indexRange == ranges.Length)
            {
                return SeachNumberInRange(arrayToSearch, ranges, numberIndex + 1, endNumberIndex, 0);
            }
            else
            {
                if (ranges[indexRange] == null)
                {
                    return SeachNumberInRange(arrayToSearch, ranges, numberIndex, endNumberIndex, indexRange + 1);
                }
                else if (ranges[indexRange].Length != 2)
                {
                    return SeachNumberInRange(arrayToSearch, ranges, numberIndex, endNumberIndex, indexRange + 1);
                }
                else if (ranges[indexRange][0] <= arrayToSearch[numberIndex] && ranges[indexRange][1] >= arrayToSearch[numberIndex])
                {
                    return SeachNumberInRange(arrayToSearch, ranges, numberIndex + 1, endNumberIndex, 0) + 1;
                }
                else
                {
                    return SeachNumberInRange(arrayToSearch, ranges, numberIndex, endNumberIndex, indexRange + 1);
                }
            }
        }

        private static bool CheackingArrayRangeOnError(decimal[][] ranges, int index)
        {
            if (ranges.Length == index)
            {
                return false;
            }
            else if (ranges[index] == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }
            else if (ranges[index].Length != 2)
            {
                if (ranges[index].Length == 0)
                {
                    return CheackingArrayRangeOnError(ranges, index + 1);
                }
                else
                {
                    return true;
                }
            }
            else if (ranges[index][0] > ranges[index][1])
            {
                return true;
            }
            else
            {
                return CheackingArrayRangeOnError(ranges, index + 1);
            }
        }
    }
}
