using Company.Text.Transliteration.FuzzyTransliteration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration
{
    public class WordDictionary
    {
        private static WordDictionary singleton = null;
        private static object sync = new object();

        private UrduTrie trie = new UrduTrie();

        private WordDictionary() { }

        public static WordDictionary Instance
        {
            get
            {
                if (singleton == null)
                {
                    lock (sync)
                    {
                        singleton = new WordDictionary();
                        singleton.Initialize();
                    }
                }
                return singleton;
            }
        }

        public List<string> GetStrictAutoComplete(string word, string prefix)
        {
            return null;
        }

        public List<string> GetUrduMatches(string urdu)
        {
            var results = new List<string>();

            if (urdu.Length > 0)
            {
                results = trie.GetMatches(urdu);
            }

            return results;
        }

        public List<string> GetEnglish2UrduMatches(string word)
        {
            List<string> result = new List<string>();

            result = trie.GetFuzzyMatches(EncodeWord(word));
            this.ApplyRejectionFilter(word, result);

            return result;
        }

        private void ApplyRejectionFilter(string word, List<string> result)
        {
            // Reject results based on rules such as:
            // 1 - Consonant matching.
            // 2 - .....
        }

        private string EncodeWord(string english)
        {
            string result = RemoveDuplicatesAndAddVowels(english);
            return result;
        }

        private string vowels = "aeiou";
        private string compunds = "cksgp";

        private string RemoveDuplicatesAndAddVowels(string english)
        {
            char[] res = new char[english.Length * 2];

            int x = 0;
            int y = 0;
            bool prevWsVowel = true;
            bool currIsVowel = false;
            while (x < english.Length)
            {

                if (x > 0 && english[x - 1] == english[x])
                {
                    if (!(x > 1 && english[x - 1] == 'h' && !compunds.Contains(english[x - 2])))
                    {
                        x++;
                        continue;
                    }
                }

                currIsVowel = vowels.Contains(english[x]);

                if (currIsVowel)
                {
                    prevWsVowel = true;
                    res[y++] = english[x++];
                    continue;
                }

                if (!prevWsVowel)
                {
                    res[y++] = '0';
                }

                res[y++] = english[x++];
                prevWsVowel = false;
            }

            return new System.String(res, 0, y);
        }

        public class CharacterMatch
        {
            public char[] Exact;
            public char[] Fuzzy;
        }

        private CharacterMatch GetMatchingCharacters(char input)
        {
            switch (input)
            {
                case 'a': return new CharacterMatch() { Exact = new char[] { 'ا', 'آ' }, Fuzzy = new char[] { 'ا', 'آ', 'ی', 'ع' } };
                case 'b': return new CharacterMatch() { Exact = new char[] { 'ب' }, Fuzzy = new char[] { 'ب' } };
                case 'c': return new CharacterMatch() { Exact = new char[] { 'س', 'ث', 'ص' }, Fuzzy = new char[] { 'ک', 'س', 'ث', 'ص' } };
                case 'd': return new CharacterMatch() { Exact = new char[] { 'د', 'ڈ' }, Fuzzy = new char[] { 'د', 'ڈ' } };
                case 'e': return new CharacterMatch() { Exact = new char[] { 'ع' }, Fuzzy = new char[] { 'ع', 'ی', 'ا', 'آ' } };
                case 'f': return new CharacterMatch() { Exact = new char[] { 'ف' }, Fuzzy = new char[] { 'ف' } };
                case 'g': return new CharacterMatch() { Exact = new char[] { 'گ' }, Fuzzy = new char[] { 'گ' } };
                case 'h': return new CharacterMatch() { Exact = new char[] { 'ہ', 'ح' }, Fuzzy = new char[] { 'ہ', 'ح' } };
                case 'i': return new CharacterMatch() { Exact = new char[] { 'ع' }, Fuzzy = new char[] { 'ا', 'آ', 'ی', 'ع' } };
                case 'j': return new CharacterMatch() { Exact = new char[] { 'ج' }, Fuzzy = new char[] { 'ج' } };
                case 'k': return new CharacterMatch() { Exact = new char[] { 'ک' }, Fuzzy = new char[] { 'ک' } };
                case 'l': return new CharacterMatch() { Exact = new char[] { 'ل' }, Fuzzy = new char[] { 'ل' } };
                case 'm': return new CharacterMatch() { Exact = new char[] { 'م' }, Fuzzy = new char[] { 'م' } };
                case 'n': return new CharacterMatch() { Exact = new char[] { 'ن' }, Fuzzy = new char[] { 'ن' } };
                case 'o': return new CharacterMatch() { Exact = new char[] { 'و' }, Fuzzy = new char[] { 'و', 'ا', 'آ', 'ی', 'ع' } };
                case 'p': return new CharacterMatch() { Exact = new char[] { 'پ' }, Fuzzy = new char[] { 'پ' } };
                case 'q': return new CharacterMatch() { Exact = new char[] { 'ق' }, Fuzzy = new char[] { 'ق' } };
                case 'r': return new CharacterMatch() { Exact = new char[] { 'ر', 'ڑ' }, Fuzzy = new char[] { 'ر', 'ڑ' } };
                case 's': return new CharacterMatch() { Exact = new char[] { 'س', 'ث', 'ص' }, Fuzzy = new char[] { 'س', 'ث', 'ص' } };
                case 't': return new CharacterMatch() { Exact = new char[] { 'ت', 'ٹ', 'ط' }, Fuzzy = new char[] { 'ت', 'ٹ', 'ط' } };
                case 'u': return new CharacterMatch() { Exact = new char[] { 'و', 'ا', 'آ', 'ی', 'ع' }, Fuzzy = new char[] { 'و', 'ا', 'آ', 'ی', 'ع' } };
                case 'v': return new CharacterMatch() { Exact = new char[] { 'و' }, Fuzzy = new char[] { 'و' } };
                case 'w': return new CharacterMatch() { Exact = new char[] { 'و' }, Fuzzy = new char[] { 'و' } };
                case 'x': return new CharacterMatch() { Exact = new char[] { 'ش' }, Fuzzy = new char[] { 'ش' } };
                case 'y': return new CharacterMatch() { Exact = new char[] { 'ے', 'ی' }, Fuzzy = new char[] { 'ے', 'ی' } };
                case 'z': return new CharacterMatch() { Exact = new char[] { 'ز', 'ذ', 'ض', 'ظ' }, Fuzzy = new char[] { 'ز', 'ذ', 'ض', 'ظ' } };
                case '0': return new CharacterMatch() { Exact = new char[] { 'ا', 'آ', 'ی', 'ع' }, Fuzzy = new char[] { 'ا', 'آ', 'ی', 'ع' } };
            }

            return new CharacterMatch() { };
        }


        private void Initialize()
        {
            // Load dictionary from file
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            string[] words = System.IO.File.ReadAllLines("wordlist.txt");

            foreach (string w in words)
            {
                if (w.Length > 0)
                {
                    trie.AddWord(w);
                }
            }
        }


    }
}
