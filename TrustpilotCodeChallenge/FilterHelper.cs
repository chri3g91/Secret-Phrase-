
using System;
using System.Diagnostics;


namespace TrustpilotCodeChallenge
{
    public class FilterHelper
    {
        public string FilterWord(Words filteredWords, string hash)
        {
            #region variables
            var hashHelper = new HashHelper();
            var matchedPhrase = string.Empty;
            var isMatch = false;
            var i = 0;
            var tracker = 0;   
            var sw = new Stopwatch();
            var ts = new TimeSpan();
            #endregion

            while (!isMatch && i < filteredWords.SevenLetterWords.Count)
            {
                sw.Restart();
                foreach (var fourChars in filteredWords.FourLetterWords)
                {
                    var z = 0;
                    while (!isMatch && z < filteredWords.SevenLetterWords.Count)
                    {
                        if (i != z)
                        {
                            tracker++;
                            isMatch = hashHelper.CheckIfHashMatches(filteredWords.SevenLetterWords[i] + " " + filteredWords.SevenLetterWords[z] + " " + fourChars, hash);
                            if (isMatch)
                                matchedPhrase = filteredWords.SevenLetterWords[i] + " " + filteredWords.SevenLetterWords[z] + " " + fourChars;
                        }
                        z++;
                    }
                }
                sw.Stop();
                var timeElapsed = ts.Add(sw.Elapsed);
                ts = timeElapsed;
                Console.WriteLine("Still searching.....Elapsed time: " + timeElapsed);
                i++;
            }
            Console.WriteLine("Total number of combos attempted: " + tracker);
            return matchedPhrase;
        }


    }
}
