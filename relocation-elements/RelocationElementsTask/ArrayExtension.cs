﻿using System;

namespace RelocationElementsTask
{
    /// <summary>
    /// Class for operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Moves all of the elements with set value to the end, preserving the order of the other elements.
        /// </summary>
        /// <param name="source"> Source array. </param>
        /// <param name="value">Source value.</param>
        /// <exception cref="ArgumentNullException">Thrown when source array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when source array is empty.</exception>
        public static void MoveToTail(int[] source, int value)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("source array is empty", nameof(source));
            }

            int steps = 1;
            for (int i = 0; i < source.Length - steps; i++)
            {
                if (source[i] == value)
                {
                    MoveElement(ref source, ref steps, value, i);
                }
            }
        }

        private static void MoveElement(ref int[] source, ref int steps, int value, int index)
        {
            if (source[index + steps] == value && (source[index + steps] == value && index + steps != source.Length - 1))
            {
                steps++;
                MoveElement(ref source, ref steps, value, index);
            }
            else
            {
                int movableNumber = source[index + steps];
                source[index + steps] = value;
                source[index] = movableNumber;
            }
        }
    }
}
