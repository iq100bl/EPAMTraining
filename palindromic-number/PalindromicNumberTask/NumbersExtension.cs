using System;

namespace PalindromicNumberTask
{
    /// <summary>
    /// Provides static method for working with integers.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Determines if a number is a palindromic number, see https://en.wikipedia.org/wiki/Palindromic_number.
        /// </summary>
        /// <param name="number">Verified number.</param>
        /// <returns>true if the verified number is palindromic number; otherwise, false.</returns>
        /// <exception cref="ArgumentException"> Thrown when source number is less than zero. </exception>
        public static bool IsPalindromicNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is less than zero");
            }
            else if (number >= 0 && number < 10)
            {
                return true;
            }

            int sizeNumber = 0;
            int tempNumber = number;
            while (tempNumber > 0)
            {
                tempNumber /= 10;
                sizeNumber++;
            }

            return CalculationPalindromic(number, sizeNumber);
        }

        private static bool CalculationPalindromic(int number, int sizeNumber)
        {
            if (sizeNumber <= 1)
            {
                return true;
            }
            else if ((int)(number / Math.Pow(10, sizeNumber - 1)) == number % 10)
            {
                return CalculationPalindromic((int)((number % Math.Pow(10, sizeNumber - 1)) / 10), sizeNumber - 2);
            }
            else
            {
                return false;
            }
        }
    }
}
