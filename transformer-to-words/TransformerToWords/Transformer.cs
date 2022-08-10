using System;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public string[] Transform(double[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(source));
            }

            string[] numbers = Array.Empty<string>();
            for (int i = 0; i < source.Length; i++)
            {
                Array.Resize(ref numbers, numbers.Length + 1);
                numbers[i] = source[i].ToString(CultureInfo.InvariantCulture);
            }

            StringBuilder[] accumulator = Array.Empty<StringBuilder>();
            for (var i = 0; i < source.Length; i++)
            {
                Array.Resize<StringBuilder>(ref accumulator, accumulator.Length + 1);
                accumulator[i] = new StringBuilder();
                var number = source[i];
                switch (number)
                {
                    case double.Epsilon:
                        accumulator[i].Append("Double Epsilon");
                        break;
                    case double.NaN:
                        accumulator[i].Append("Not a Number");
                        break;
                    case double.NegativeInfinity:
                        accumulator[i].Append("Negative Infinity");
                        break;
                    case double.PositiveInfinity:
                        accumulator[i].Append("Positive Infinity");
                        break;
                    default:
                        foreach (char c in numbers[i])
                        {
                            switch (c)
                            {
                                case '1':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("one");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("one");
                                    }

                                    break;
                                case '2':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("two");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("two");
                                    }

                                    break;
                                case '3':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("three");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("three");
                                    }

                                    break;
                                case '4':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("four");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("four");
                                    }

                                    break;
                                case '5':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("five");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("five");
                                    }

                                    break;
                                case '6':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("six");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("six");
                                    }

                                    break;
                                case '7':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("seven");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("seven");
                                    }

                                    break;
                                case '8':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("eight");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("eight");
                                    }

                                    break;
                                case '9':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("nine");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("nine");
                                    }

                                    break;
                                case '0':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("zero");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("zero");
                                    }

                                    break;
                                case '-':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("minus");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("minus");
                                    }

                                    break;
                                case '.':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("point");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("point");
                                    }

                                    break;
                                case 'E':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("E");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("E");
                                    }

                                    break;
                                case '+':
                                    if (accumulator[i].Length == 0)
                                    {
                                        accumulator[i].Append("plus");
                                    }
                                    else
                                    {
                                        accumulator[i].Append(' ').Append("plus");
                                    }

                                    break;
                            }
                        }

                        accumulator[i][0] = char.ToUpper(accumulator[i][0], CultureInfo.CreateSpecificCulture("en-EN"));
                        break;
                }
            }

            string[] result = Array.Empty<string>();
            for (var i = 0; i < accumulator.Length; i++)
            {
                Array.Resize(ref result, result.Length + 1);
                result[i] = accumulator[i].ToString();
            }

            return result;
        }
    }
}
