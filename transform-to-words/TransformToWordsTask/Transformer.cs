using System;
using System.Globalization;
using System.Text;

#pragma warning disable CA1822

namespace TransformToWordsTask
{
    /// <summary>
    /// Provides transformer methods.
    /// </summary>
    public sealed class Transformer
    {
        /// <summary>
        /// Converts number's digital representation into words.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>Words representation.</returns>
        public string TransformToWords(double number)
        { 
            var numbers = number.ToString(CultureInfo.CreateSpecificCulture("en-EN"));
            StringBuilder accumulator = new StringBuilder();
            switch (number)
            {
                case double.Epsilon:
                    accumulator.Append("Double Epsilon");
                    break;
                case double.NaN:
                    accumulator.Append("NaN");
                    break;
                case double.NegativeInfinity:
                    accumulator.Append("Negative Infinity");
                    break;
                case double.PositiveInfinity:
                    accumulator.Append("Positive Infinity");
                    break;
                default:
                    foreach (char c in numbers)
                    {
                        switch (c)
                        {
                            case '1':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("one");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("one");
                                }

                                break;
                            case '2':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("two");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("two");
                                }

                                break;
                            case '3':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("three");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("three");
                                }
                                
                                break;
                            case '4':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("four");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("four");
                                }
                                
                                break;
                            case '5':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("five");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("five");
                                }
                                
                                break;
                            case '6':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("six");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("six");
                                }
                                
                                break;
                            case '7':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("seven");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("seven");
                                }
                                
                                break;
                            case '8':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("eight");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("eight");
                                }
                                
                                break;
                            case '9':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("nine");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("nine");
                                }
                                
                                break;
                            case '0':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("zero");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("zero");
                                }
                                
                                break;
                            case '-':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("minus");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("minus");
                                }
                                
                                break;
                            case '.':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("point");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("point");
                                }
                                
                                break;
                            case 'E':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("E");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("E");
                                }
                                
                                break;
                            case '+':
                                if (accumulator.Length == 0)
                                {
                                    accumulator.Append("plus");
                                }
                                else
                                {
                                    accumulator.Append(' ').Append("plus");
                                }
                                
                                break;
                        }
                    }

                    accumulator[0] = char.ToUpper(accumulator[0], CultureInfo.CreateSpecificCulture("en-EN"));
                    break;
            }

            return accumulator.ToString();
        }
    }
}
