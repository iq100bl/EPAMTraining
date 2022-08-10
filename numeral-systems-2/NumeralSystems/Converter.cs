using System;

namespace NumeralSystems
{
    /// <summary>
    /// Converts a string representations of a numbers to its integer equivalent.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-octal alphabetic characters).
        /// Valid octal alphabetic characters: 0,1,2,3,4,5,6,7.
        /// </exception>
        public static int ParsePositiveFromOctal(this string source)
        {
            try
            {
                var number = Convert.ToInt32(source, 8);
                if (number < 0)
                {
                    throw new ArgumentException("Source string presents a negative number", nameof(source));
                }

                return number;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid number in source", nameof(source));
            }            
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-decimal alphabetic characters).
        /// Valid decimal alphabetic characters: 0,1,2,3,4,5,6,7,8,9.
        /// </exception>
        public static int ParsePositiveFromDecimal(this string source)
        {
            try
            {
                var number = Convert.ToInt32(source, 10);
                if (number < 0)
                {
                    throw new ArgumentException("Source string presents a negative number", nameof(source));
                }

                return number;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid number in source", nameof(source));
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-hex alphabetic characters).
        /// Valid hex alphabetic characters: 0,1,2,3,4,5,6,7,8,9,A(or a),B(or b),C(or c),D(or d),E(or e),F(or f).
        /// </exception>
        public static int ParsePositiveFromHex(this string source)
        {
            try
            {
                var number = Convert.ToInt32(source, 16);
                if (number < 0)
                {
                    throw new ArgumentException("Source string presents a negative number", nameof(source));
                }

                return number;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid number in source", nameof(source));
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Does not represent a positive number in hex numeral system", nameof(source));
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParsePositiveByRadix(this string source, int radix)
        {
            try
            {
                if (radix % 8 != 0 && radix % 10 != 0 && radix % 16 != 0)
                {
                    throw new ArgumentException("The radix is not equal 8, 10 or 16", nameof(source));
                }

                var number = Convert.ToInt32(source, radix);
                if (number < 0)
                {
                    throw new ArgumentException("Source string presents a negative number", nameof(source));
                }

                return number;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid number in source", nameof(source));
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Does not represent a positive number in hex numeral system", nameof(source));
            }
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A signed decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParseByRadix(this string source, int radix)
        {
            try
            {
                if (radix % 8 != 0 && radix % 10 != 0 && radix % 16 != 0)
                {
                    throw new ArgumentException("The radix is not equal 8, 10 or 16", nameof(source));
                }

                var number = Convert.ToInt32(source, radix);
                return number;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid number in source", nameof(source));
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Does not represent a positive number in hex numeral system", nameof(source));
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromOctal(this string source, out int value)
        {
            try
            {
                value = ParsePositiveFromOctal(source);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal yes value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromDecimal(this string source, out int value)
        {
            try
            {
                value = ParsePositiveFromDecimal(source);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal no value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromHex(this string source, out int value)
        {
            try
            {
                value = ParsePositiveFromHex(source);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive <see cref="decimal"/> value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParsePositiveByRadix(this string source, int radix, out int value)
        {
            try
            {                
                value = ParsePositiveByRadix(source, radix);
                return true;
            }
            catch (ArgumentException)
            {
                if ((radix % 8 != 0 && radix % 10 != 0 && radix % 16 != 0) || radix == 0)
                {
                    throw new ArgumentException("The radix is not equal 8, 10 or 16 or equal zero", nameof(source));
                }

                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal or value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParseByRadix(this string source, int radix, out int value)
        {
            try
            {
                value = ParseByRadix(source, radix);
                return true;
            }
            catch (ArgumentException)
            {
                if ((radix % 8 != 0 && radix % 10 != 0 && radix % 16 != 0) || radix == 0)
                {
                    throw new ArgumentException("The radix is not equal 8, 10 or 16 or equal zero", nameof(source));
                }

                value = 0;
                return false;
            }
        }
    }
}
