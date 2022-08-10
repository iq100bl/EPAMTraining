using System;
using System.IO;
using System.Text;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            return streamReader.ReadToEnd().Split(Environment.NewLine);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "<Ожидание>")]
        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            StringBuilder result = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                if (char.IsLetterOrDigit((char)streamReader.Peek()))
                {
                result.Append((char)streamReader.Read());
                }
                else
                {
                    return result;
                }
            }

            return result;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            char[][] result = new char[(int)Math.Ceiling((decimal)streamReader.BaseStream.Length / (decimal)arraySize)][];
            int i = 0;
            int i2 = 0;
            while (!streamReader.EndOfStream)
            {
                if (i2 == arraySize)
                {
                    i++;
                    i2 = 0;
                }

                if (i2 == 0)
                {
                    result[i] = new char[arraySize];
                    int size = (int)(streamReader.BaseStream.Length % arraySize);
                    if (size == 0 || i < result.Length - 1)
                    {
                        Array.Resize(ref result[i], arraySize);
                    }
                    else
                    {
                        Array.Resize(ref result[i], size);
                    }
                }

                result[i][i2] = (char)streamReader.Read();
                i2++;
            }

            return result;
        }
    }
}
