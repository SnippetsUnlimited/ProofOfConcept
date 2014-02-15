using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.SpellChecker.Library
{
    public class EnglishDictionary
      {
        private static EnglishDictionary singleton = null;
        private static object sync = new object();

        private const string alphabets = "abcdefghijklmnopqrstuvwxyz";
        private Dictionary<char, HashSet<string>> index = null;

        private BKTree bkTree = new BKTree();

        private EnglishDictionary() { }

        public static EnglishDictionary Instance
        {
            get
            {
                if (singleton == null)
                {
                    lock(sync)
                    {
                        singleton = new EnglishDictionary();
                    }
                }
                return singleton;
            }
        }

        public void Initialize(object[] settings)
        {
            // Setup sub dictionaries
            index = new Dictionary<char, HashSet<string>>();

            foreach(char c in alphabets)
            {
                index.Add(c, new HashSet<string>());
            }

            // Load dictionary from file
            LoadDictionary((string)settings[0]);
        }

        public List<string> GetMatches(string litral)
        {
            var list = new List<string>();

            if (litral.Length > 0)
            {
                var hashset = index[litral[0]];

                foreach (string s in hashset)
                {
                    if (litral.Length <= s.Length && string.Compare(litral, s.Substring(0, litral.Length)) == 0)
                    {
                        list.Add(s);
                    }
                }
            }

            return list;
        }


        public List<string> GetSuggestions(string litral, int tolerance)
        {
            bkTree.Tolerance = tolerance;
            return bkTree.GetSuggestions(litral);
        }


        private void LoadDictionary(string dictionaryPath)
        {
            string[] words = System.IO.File.ReadAllLines(dictionaryPath);

            foreach (string w in words)
            {
                if (w.Length > 0)
                {
                    index[w[0]].Add(w);
                    bkTree.AddWord(w);
                }
            }



        }

    }
}
