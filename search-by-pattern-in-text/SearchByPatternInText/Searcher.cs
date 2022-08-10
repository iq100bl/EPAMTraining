using System;
using System.Collections.Generic;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string text, string pattern, bool overlap)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Invalid text", nameof(text));
            }

            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentException("Invalid pattern", nameof(pattern));
            }

            List<int> result = new List<int>();

            int step;
            if (overlap)
            {
                step = 1;
            }
            else
            {
                step = pattern.Length;
            }

            int i = 0;
            while (true)
            {
                int accumulator = text.IndexOf(pattern, i, StringComparison.InvariantCultureIgnoreCase);
                if (accumulator == -1)
                {
                    return result.ToArray();
                }
                else
                {
                    result.Add(accumulator + 1);
                    i = accumulator + step;
                }
            }
        }
    }
}
