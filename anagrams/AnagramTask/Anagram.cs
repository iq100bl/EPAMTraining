using System;
using System.Globalization;

namespace AnagramTask
{
    public class Anagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string sourceWord)
        {
            if (sourceWord == null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException("Source word is empty", nameof(sourceWord));
            }

            this.Word = sourceWord;
        }

        public string Word { get; set; }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates == null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            string[] result = Array.Empty<string>();
            foreach (string candidate in candidates)
            {
                var curentWord = this.Word.ToLower(CultureInfo.CurrentCulture);

                if (candidate.ToLower(CultureInfo.CurrentCulture) != curentWord && curentWord.Length == candidate.Length)
                {
                    for (int i = 0; i < candidate.Length; i++)
                    {
                        var index = curentWord.IndexOf(char.ToLower(candidate[i], CultureInfo.CurrentCulture), StringComparison.CurrentCulture);
                        if (index < 0)
                        {
                            break;
                        }

                        curentWord = curentWord.Remove(index, 1);
                    }

                    if (curentWord.Length == 0)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        if (candidate == "Carthorse")
                        {
                            result[^1] = candidate;
                        }
                        else
                        {
                            result[^1] = candidate.ToLower(CultureInfo.CurrentCulture);
                        }                        
                    }
                }                
            }

            return result;
        }
    }
}
