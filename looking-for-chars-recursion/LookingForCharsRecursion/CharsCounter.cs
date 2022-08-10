using System;

namespace LookingForCharsRecursion
{
    public static class CharsCounter
    {
        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <returns>The number of occurrences of all characters.</returns>
        public static int GetCharsCount(string str, char[] chars)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (str.Length == 0)
            {
                if (chars.Length == 0)
                {
                    return 0;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(str));
                }
            }

            return GetCharsCount(str, chars, 0, str.Length - 1, int.MaxValue);
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            return GetCharsCount(str, chars, startIndex, endIndex, int.MaxValue);
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "StartIndex more than EndIndex");
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            if (str.Length == 0)
            {
                if (chars.Length == 0)
                {
                    return 0;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(str));
                }
            }

            if (startIndex > str.Length - 1 || startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            int result = ChangeCharsForSeach(str[startIndex.. (endIndex + 1)], chars, 0);
            if (result > limit)
            {
                return limit;
            }
            else
            {
                return result;
            }
        }

        private static int ChangeCharsForSeach(string str, char[] chars, int index)
        {
            if (chars.Length == index)
            {
                return 0;
            }
            else
            {
                var result = SeachCharInStr(str, chars[index]);
                return result + ChangeCharsForSeach(str, chars, index + 1);
            }
        }

        private static int SeachCharInStr(string str, char letter)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            else if (str[0] == letter)
            {
                return SeachCharInStr(str[1..], letter) + 1;
            }
            else
            {
                return SeachCharInStr(str[1..], letter);
            }
        }
    }
}
