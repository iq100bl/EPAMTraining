using System;
using System.Collections.Generic;

#pragma warning disable S2368

namespace JaggedArrays
{
    public class MaxElementComparer : IComparer<int[]>
    {
        int IComparer<int[]>.Compare(int[] x, int[] y)
        {
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            if (x == null && y == null)
            {
                return 0;
            }
            else if (y == null)
            {
                return 1;
            }
            else if (x == null)
            {
                return -1;
            }
            else
            {
                Array.ForEach(x, (x) =>
                {
                    if (x > maxX)
                    {
                        maxX = x;
                    }
                });
                Array.ForEach(y, (y) =>
                {
                    if (y > maxY)
                    {
                        maxY = y;
                    }
                });
                if (maxX > maxY)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
