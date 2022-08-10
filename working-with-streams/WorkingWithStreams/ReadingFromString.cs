using System;
using System.IO;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
            {
            return stringReader.ReadToEnd();
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
            return stringReader.ReadLine();
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            int currentNumberChar = stringReader.Read();
            if (currentNumberChar == -1)
            {
                currentChar = ' ';
                return false;
            }

            currentChar = (char)currentNumberChar;
            return currentChar != -1;
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            int currentNumberChar = stringReader.Peek();
            if (currentNumberChar == -1)
            {
                currentChar = ' ';
                return false;
            }

            currentChar = (char)currentNumberChar;
            return currentChar != -1;
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            return stringReader.ReadLine().ToCharArray(0, count);
        }
    }
}
