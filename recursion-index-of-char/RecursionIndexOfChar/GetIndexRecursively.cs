using System;

namespace RecursionIndexOfChar
{
    public static class GetIndexRecursively
    {
        public static int GetIndexOfChar(string str, char value) // My metod is not very correctly, but i'm tricky:)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return GetIndexOfChar(str, value, 0, str.Length - 1);
        }

        public static int GetIndexOfChar(string str, char value, int startIndex, int count)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (startIndex > str.Length - 1 || count < 1)
            {
                return -1;
            }

            if (str[startIndex] == value)
            {
                return startIndex;
            }

            if (count == 1 || startIndex > str.Length - 1)
            {
                return -1;
            }
            else
            {
                return GetIndexOfChar(str, value, startIndex + 1, count - 1);
            }
        }
    }
}
