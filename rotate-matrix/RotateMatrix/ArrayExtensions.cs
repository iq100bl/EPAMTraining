using System;

namespace RotateMatrix
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Rotates the image clockwise by 90° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate90DegreesClockwise(this int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int size = matrix.GetLength(0) - 1;
            int extraStep = 0;
            if (size % 2 == 1)
            {
                extraStep = 1;   
            }

            for (int i = 0; i < size + extraStep; i++)
            {
                for (int j = i; j < size; j++)
                {
                    int savedNumber = matrix[j, size];
                    matrix[j, size] = matrix[i, j];
                    int savedNumber2 = matrix[size, size + i - j];
                    matrix[size, size + i - j] = savedNumber;
                    savedNumber = matrix[size + i - j, i];
                    matrix[size + i - j, i] = savedNumber2;
                    matrix[i, j] = savedNumber;
                }

                size -= 1;
            }
        }

        /// <summary>
        /// Rotates the image counterclockwise by 90° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate90DegreesCounterClockwise(this int[,] matrix)
        {
            Rotate270DegreesClockwise(matrix);
        }

        /// <summary>
        /// Rotates the image clockwise by 180° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate180DegreesClockwise(this int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int size = matrix.GetLength(0) - 1;
            int extraStep = 0;
            if (size % 2 == 0)
            {
                extraStep = 1;
            }

            for (int i = 0; i <= size / 2; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    int savedNumber = matrix[size - i, size - j];
                    matrix[size - i, size - j] = matrix[i, j];
                    matrix[i, j] = savedNumber;
                }

                if (i + extraStep > size / 2)
                {
                    for (int j = 0; j <= size / 2; j++)
                    {
                        int savedNumber = matrix[size - i, size - j];
                        matrix[size - i, size - j] = matrix[i, j];
                        matrix[i, j] = savedNumber;
                    }
                }
            }
        }

        /// <summary>
        /// Rotates the image counterclockwise by 180° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate180DegreesCounterClockwise(this int[,] matrix)
        {
            Rotate180DegreesClockwise(matrix);
        }

        /// <summary>
        /// Rotates the image clockwise by 270° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate270DegreesClockwise(this int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int size = matrix.GetLength(0) - 1;
            int extraStep = 0;
            if (size % 2 == 1)
            {
                extraStep = 1;
            }

            for (int i = 0; i < size + extraStep; i++)
            {
                for (int j = i; j < size; j++)
                {
                    int savedNumber = matrix[size + i - j, i];
                    matrix[size + i - j, i] = matrix[i, j];
                    int savedNumber2 = matrix[size, size + i - j];
                    matrix[size, size + i - j] = savedNumber;
                    savedNumber = matrix[j, size];
                    matrix[j, size] = savedNumber2;
                    matrix[i, j] = savedNumber;
                }

                size -= 1;
            }
        }

        /// <summary>
        /// Rotates the image counterclockwise by 270° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate270DegreesCounterClockwise(this int[,] matrix)
        {
            Rotate90DegreesClockwise(matrix);
        }

        /// <summary>
        /// Rotates the image clockwise by 360° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate360DegreesClockwise(this int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }

        /// <summary>
        /// Rotates the image counterclockwise by 360° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate360DegreesCounterClockwise(this int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }
    }
}
