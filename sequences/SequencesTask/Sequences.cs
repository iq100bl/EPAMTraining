using System;
using System.Collections.Generic;

namespace SequencesTask
{
    public static class Sequences
    {
        /// <summary>
        /// Find all the contiguous substrings of length length in given string of digits in the order that they appear.
        /// </summary>
        /// <param name="numbers">Source string.</param>
        /// <param name="length">Length of substring.</param>
        /// <returns>All the contiguous substrings of length n in that string in the order that they appear.</returns>
        /// <exception cref="ArgumentException">
        /// Throw if length of substring less and equals zero
        /// -or-
        /// more than length of source string
        /// - or-
        /// source string containing a non-digit character
        /// - or
        /// source string is null or empty or white space.
        /// </exception>
        public static string[] GetSubstrings(string numbers, int length)
        {
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
            {
                throw new ArgumentException("Number is not valid", nameof(numbers));
            }
            
            if (length <= 0)
            {
                throw new ArgumentException("Length is not valid", nameof(numbers));
            }

            if (numbers.Length < length)
            {
                throw new ArgumentException("Length is not valid", nameof(numbers));
            }

            if (!int.TryParse(numbers, out _))
            {
                foreach (char number in numbers)
                {
                    if (!char.IsNumber(number))
                    {
                        throw new ArgumentException("Length is not valid", nameof(numbers));
                    }
                }
            }

            if (numbers.Length == length)
            {
                return new string[1] { numbers };
            }

            List<string> substrings = new List<string>();
            char[] accumulator = new char[length];
            for (int i = 0; i + length <= numbers.Length; i++)
            {
                numbers.CopyTo(i, accumulator, 0, length);
                substrings.Add(new string(accumulator));
            }

            string[] result = substrings.ToArray();
            return result;
        }
    }
}
