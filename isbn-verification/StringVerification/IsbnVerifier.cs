using System;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Source string cannot be null or empty or whitespace.", nameof(number));
            }

            var numbers = number.ToCharArray();
            var i = 10;
            var sum = 0;
            var accumulator = 0;
            foreach (char c in numbers)
            {
                if (i <= 0)
                {
                    return false;
                }
                else if (char.IsDigit(c))
                {
                    sum += (c - '0') * i;
                    i--;
                }
                else if (c == 'X')
                {
                    if (i != 1)
                    {
                        return false;
                    }

                    sum += 10 * i;
                    i--;
                }
                else if (c == '-')
                {
                    if (i != 9 && i != 6 && i != 3 && i != 1)
                    {
                        return false;
                    }

                    if (i == accumulator)
                    {
                        return false;
                    }

                    accumulator = i;
                }
                else
                {
                    return false;
                }
            }

            if (i != 0)
            {
                return false;
            }

            if (sum % 11 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
