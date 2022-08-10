using System;
using System.IO;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace WorkingWithStreams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            while (!streamReader.EndOfStream)
            {
                if (streamReader.Peek() != -1)
                {
                    outputWriter.Write(streamReader.Read());
                }
            }
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            outputWriter.AutoFlush = true;
            while (!streamReader.EndOfStream)
            {
                if (streamReader.Peek() != -1)
                {
                    outputWriter.Write((char)streamReader.Read());
                }
            }
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            while (!contentReader.EndOfStream)
            {
                if (contentReader.Peek() != -1)
                {
                    outputWriter.Write("0" + Convert.ToString(contentReader.Read(), 16).ToUpper(System.Globalization.CultureInfo.CurrentCulture));
                }
            }
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            int i = 1;
            while (!contentReader.EndOfStream || contentReader.Peek() != -1)
            {
                outputWriter.Write(i.ToString("D3", null) + " ");
                while ((char)contentReader.Peek() != '\n' && contentReader.Peek() != -1)
                {
                    outputWriter.Write((char)contentReader.Read());
                }

                if (contentReader.Peek() != -1)
                {
                    outputWriter.Write((char)contentReader.Read());
                    i++;
                }
            }

            outputWriter.Write("\n");
            outputWriter.Flush();
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            var words = wordsReader.ReadToEnd().Split('\n');
            var content = contentReader.ReadToEnd();
            foreach (var word in words)
            {
                var index = content.IndexOf(word, StringComparison.CurrentCulture);
                if (index != -1)
                {
                    content = content.Remove(index, word.Length);
                }
            }

            outputWriter.Write(content);
        }
    }
}
