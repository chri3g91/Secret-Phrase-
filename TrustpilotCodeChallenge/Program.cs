
using System;


namespace TrustpilotCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting search....   " + DateTime.Now.TimeOfDay);
            var response = FindTheSecretPhrase("poultry outwits ants", "4624d200580677270a54ccff86b9610e");
            Console.WriteLine("Search ended.......   " + DateTime.Now.TimeOfDay + " \r\n The outcome was: " + response); 
            Console.ReadKey();
        }

       

        private static string FindTheSecretPhrase(string phrase, string hash)
        {
            #region variables 
            var filterHelper = new FilterHelper();
            var wordsHelper = new WordListHelper();
            var matchFound = "";
            var z = 0;
            #endregion

            var words = wordsHelper.GetAllWords(phrase);
            if(words == null)
                return " Error: could not retrieve the words list from the file. ";
            if (words.FourLetterWords.Count == 0 || words.SevenLetterWords.Count == 0)  
                return " Unsuccessful operation: the word retrieval criteria for the given file returned 0 words. ";

            matchFound = filterHelper.FilterWord(words, hash);
            if (string.IsNullOrEmpty(matchFound))
            return " Unsuccessful operation: could not find a match to the given hash. ";

            return matchFound;
        }

        
    }

}
