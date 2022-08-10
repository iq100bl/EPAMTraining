using System;

namespace BinaryRepresentation
{
    public static class BitsManipulation
    {
        /// <summary>
        /// Get binary memory representation of signed long integer.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Binary memory representation of signed long integer.</returns>
        public static string GetMemoryDumpOf(long number)
        {
            string result = string.Empty;
            while (result.Length != 64)
            {
                result = (number & 1) + result;
                number >>= 1;
            }

            return result;
        }
    }
}
