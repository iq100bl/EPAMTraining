using System;
using System.Collections.Generic;

#pragma warning disable S2368

namespace JaggedArrays
{
    public class SumComparer : IComparer<int[]>
    {
        int IComparer<int[]>.Compare(int[] x, int[] y)
        {
            int sumX = 0;
            int sumY = 0;
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
                Array.ForEach(x, x => sumX += x);
                Array.ForEach(y, y => sumY += y);
                if (sumX > sumY)
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
