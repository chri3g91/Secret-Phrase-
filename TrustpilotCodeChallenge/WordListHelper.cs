
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TrustpilotCodeChallenge
{
    public class WordListHelper
    {
        public Words GetAllWords(string phrase)    /* CCS: a little bit of the code was reused from social.msdn.microsoft.com source */
        {
            if (string.IsNullOrEmpty(phrase))
                return null;
            
            #region variables 
            var myWords = new Words {FourLetterWords = new List<string>(),OtherWords = new List<string>(), SevenLetterWords = new List<string>()};
            FileStream stream;
            char myChar;
            int myByte;
            var word = "";
            var isNotGood = false;
            var lettersToUseList = phrase.ToCharArray().Distinct().Where(c => !char.IsWhiteSpace(c) || !phrase.Contains(c)).ToArray();
           
            #endregion

            try
            {
                stream = File.OpenRead("wordlist");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }

            while ((myByte = stream.ReadByte()) != -1)
            {
                myChar = Convert.ToChar(myByte);
                /* CCS: special characters, digits, unwanted letters */
                if (!char.IsWhiteSpace(myChar) && !isNotGood && !lettersToUseList.Contains(myChar))
                {
                    word = "";
                    isNotGood = true;
                }
                else if (!char.IsWhiteSpace(myChar) && !isNotGood)
                {
                    word += myChar;
                }
                else if (char.IsWhiteSpace(myChar) && !isNotGood)
                {
                    if (word.Length == 4)
                        myWords.FourLetterWords.Add(word);
                    else if (word.Length == 7)
                        myWords.SevenLetterWords.Add(word);
                    else
                    {
                        myWords.OtherWords.Add(word);  /* CCS: ToDo - Testing!!! */
                    }
                    word = "";
                }
                else if (char.IsWhiteSpace(myChar) && isNotGood)
                {
                    isNotGood = false;
                }
            }
            return myWords;
        }

    }

}
