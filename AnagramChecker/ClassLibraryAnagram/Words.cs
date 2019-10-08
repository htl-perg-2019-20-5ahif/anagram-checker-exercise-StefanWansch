
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramChecker
{
    public class Words
    {
        public string word1 { get; set; }
        public string word2 { get; set; }

        public Boolean check(string w1, string w2)
        {
            
            string w1Ordered = String.Concat(w1.OrderBy(c => c));
            string w2Ordered = String.Concat(w2.OrderBy(c => c));


            if(w1Ordered == w2Ordered)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> getKnownWords(String dictionaryText, String word)
        {
            List<string> knownWords = new List<string>();

            // Split the dictionary into words (by line ending \n)
            var dictionaryWords = dictionaryText.Replace("\r", "").Split('\n');
            for(int i = 0; i < dictionaryWords.Length; i++)
            {
                if (check(dictionaryWords[i],word) && dictionaryWords[i] != word)
                {
                    knownWords.Add(dictionaryWords[i]);
                }
            }
            return knownWords;
            
        }
    }
}
