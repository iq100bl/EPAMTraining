using System;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            if (number < 10 && number > -10)
            {
                return null;
            }

            ComparisonSigns result = 0;
            long rightNumber = number % 10;
            number /= 10;
            while (Math.Abs(number) > 10)
            {
                if (number % 10 == rightNumber)
                {
                    result |= ComparisonSigns.Equals;
                }
                else if (number % 10 > rightNumber)
                {
                    result |= ComparisonSigns.MoreThan;
                }
                else if (number % 10 < rightNumber)
                {
                    result |= ComparisonSigns.LessThan;
                }

                rightNumber = number % 10;
                number /= 10;
            }

            return result;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            if (number < 10 && number > -10)
            {
                return "One digit number.";
            }

            ComparisonSigns result = 0;
            long rightNumber = number % 10;
            number /= 10;
            while (Math.Abs(number) > 10)
            {
                if (number % 10 == rightNumber)
                {
                    result |= ComparisonSigns.Equals;
                }
                else if (number % 10 > rightNumber)
                {
                    result |= ComparisonSigns.MoreThan;
                }
                else if (number % 10 < rightNumber)
                {
                    result |= ComparisonSigns.LessThan;
                }

                rightNumber = number % 10;
                number /= 10;
            }

            switch ((int)result)
            {
                case 1:
                    return "Strictly Increasing.";
                case 2:
                    return "Strictly Decreasing.";
                case 3:
                    return "Unordered.";
                case 4:
                    return "Monotonous.";
                case 5:
                    return "Increasing.";
                case 6:
                    return "Decreasing.";
                case 7:
                    return "Unordered.";
                default: 
                    return null;
            }
        }
    }
}
