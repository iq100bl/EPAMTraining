using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (directions == null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            RecursionShift(source, directions, 0);
            return source;
        }

        private static void RecursionShift(int[] source, Direction[] directions, int index)
        {
            if (index < directions.Length)
            {
                var currentDirection = directions[index];
                if (currentDirection == Direction.Left)
                {
                    ShiftToLeft(source);           
                }
                else if (currentDirection == Direction.Right)
                {
                    ShiftToRight(source);
                }
                else
                {
                    throw new InvalidOperationException($"Incorrect {nameof(currentDirection)} enum value.");
                }

                RecursionShift(source, directions, index + 1);
            }           
        }

        private static void ShiftToRight(int[] source)
        {
            var rightElement = source[^1];
            Array.Copy(source[..^1], 0, source, 1, source.Length - 1);
            source[0] = rightElement;
        }

        private static void ShiftToLeft(int[] source)
        {
            var leftElement = source[0];
            Array.Copy(source[1..], source, source.Length - 1);
            source[^1] = leftElement;
        }
    }
}
