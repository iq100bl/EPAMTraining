using System;

#pragma warning disable CA1814

namespace SpiralMatrixTask
{
    /// <summary>
    /// Direction of filling array.
    /// </summary>
    internal enum Course
    {
        /// <value>
        /// Direction of filling array left.
        /// </value>
        Left,

        /// <value>
        /// Direction of filling array right.
        /// </value>
        Right,

        /// <value>
        /// Direction of filling array down.
        /// </value>
        Down,

        /// <value>
        /// Direction of filling array up.
        /// </value>
        Up,
    }

    public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Matrix size less or equal zero", nameof(size));
            }

            int currentNumer = 1;
            int[,] matrix = new int[size, size];

            /// <value>
            /// Array with vertical elements without values.
            /// </value>
            int[] vertical = new int[size];
            for (int i = 0; i < size; i++)
            {
                vertical[i] = i;
            }

            /// <value>
            /// Array with horizontal elements without values.
            /// </value>
            int[] horizontal = new int[size];
            for (int i = 0; i < size; i++)
            {
                horizontal[i] = i;
            }

            Course course = Course.Right;
            for (int i = 0; i < (size * 2) - 1; i++)
            {
                switch (course)
                {
                    case Course.Right:
                        FillMatrixLeftToRight(horizontal, vertical, ref currentNumer, ref matrix);
                        vertical = vertical[1..];
                        course = Course.Down;
                        break;
                    case Course.Down:
                        FillMatrixUpToDown(horizontal, vertical, ref currentNumer, ref matrix);
                        horizontal = horizontal[..^1];
                        course = Course.Left;
                        break;
                    case Course.Left:
                        FillMatrixRightToLeft(horizontal, vertical, ref currentNumer, ref matrix);
                        vertical = vertical[..^1];
                        course = Course.Up;
                        break;
                    case Course.Up:
                        FillMatrixDownToUp(horizontal, vertical, ref currentNumer, ref matrix);
                        horizontal = horizontal[1..];
                        course = Course.Right;
                        break;
                }
            }

            return matrix;
        }

        private static void FillMatrixLeftToRight(int[] horizontal, int[] vertical, ref int currentNumber, ref int[,] matrix)
        {
            for (int i = horizontal[0]; i <= horizontal[^1]; i++, currentNumber++)
            {
                matrix[vertical[0], i] = currentNumber;
            }
        }

        private static void FillMatrixUpToDown(int[] horizontal, int[] vertical, ref int currentNumber, ref int[,] matrix)
        {
            for (int i = vertical[0]; i <= vertical[^1]; i++, currentNumber++)
            {
                matrix[i, horizontal[^1]] = currentNumber;
            }
        }

        private static void FillMatrixRightToLeft(int[] horizontal, int[] vertical, ref int currentNumber, ref int[,] matrix)
        {
            for (int i = horizontal[^1]; i >= horizontal[0]; i--, currentNumber++)
            {
                matrix[vertical[^1], i] = currentNumber;
            }
        }

        private static void FillMatrixDownToUp(int[] horizontal, int[] vertical, ref int currentNumber, ref int[,] matrix)
        {
            for (int i = vertical[^1]; i >= vertical[0]; i--, currentNumber++)
            {
                matrix[i, horizontal[0]] = currentNumber;
            }
        }
    }
}
