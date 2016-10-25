
using System;
using System.Security.Cryptography;
using System.Text;


namespace TrustpilotCodeChallenge
{
    public class HashHelper          /* CCS: the bulk of this code was reused from msdn documentation */
    {

        public bool CheckIfHashMatches(string phraseSource, string hashSource)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var hash = GetMd5Hash(md5Hash, phraseSource);

                if (VerifyMd5Hash(hashSource, hash))
                {
                    return true;
                }
            }
            return false;
        }



        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            StringBuilder sBuilder = new StringBuilder();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
           
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            
            return sBuilder.ToString();
        }



        private bool VerifyMd5Hash(string hashSource, string hash)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashSource, hash);
        }


    }
}
