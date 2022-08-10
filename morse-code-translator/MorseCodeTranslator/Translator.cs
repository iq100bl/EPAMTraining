using System;
using System.Globalization;
using System.Text;

#pragma warning disable S2368

namespace MorseCodeTranslator
{
    public static class Translator
    {
        public static string TranslateToMorse(string message)
        {
            StringBuilder result = new StringBuilder();
            WriteMorse(MorseCodes.CodeTable, message, result, '.', '-', ' ');
            return result.ToString();
        }

        public static string TranslateToText(string morseMessage)
        {
            StringBuilder result = new StringBuilder();
            WriteText(MorseCodes.CodeTable, morseMessage, result, '.', '-', ' ');
            return result.ToString();
        }

        public static void WriteMorse(char[][] codeTable, string message, StringBuilder morseMessageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (morseMessageBuilder == null)
            {
                throw new ArgumentNullException(nameof(morseMessageBuilder));
            }

            if (codeTable == null)
            {
                throw new ArgumentNullException(nameof(codeTable));
            }

            if (!string.IsNullOrEmpty(message))
            {
                for (int i = 0; i < message.Length; i++)
                {
                    foreach (char[] code in codeTable)
                    {
                        if (code[0] == char.ToUpper(message[i], CultureInfo.CurrentCulture))
                        {
                            morseMessageBuilder.Append(code[1..]).Append(' ');
                            break;
                        }
                    }
                }

                morseMessageBuilder.Remove(morseMessageBuilder.Length - 1, 1).Replace('.', dot).Replace('-', dash).Replace(' ', separator);
            }
        }

        public static void WriteText(char[][] codeTable, string morseMessage, StringBuilder messageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            if (morseMessage == null)
            {
                throw new ArgumentNullException(nameof(morseMessage));
            }

            if (messageBuilder == null)
            {
                throw new ArgumentNullException(nameof(messageBuilder));
            }

            if (codeTable == null)
            {
                throw new ArgumentNullException(nameof(codeTable));
            }

            var arrayMorseWords = morseMessage.Replace(separator, ' ').Replace(dot, '.').Replace(dash, '-').Split(' ');
            for (int i = 0; i < arrayMorseWords.Length; i++)
            {
                foreach (char[] code in codeTable)
                {
                    if (string.Concat(code[1..]) == arrayMorseWords[i])
                    {
                        messageBuilder.Append(code[0]);
                        break;
                    }
                }
            }
        }
    }
}
