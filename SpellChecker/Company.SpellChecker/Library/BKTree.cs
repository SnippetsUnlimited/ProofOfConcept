using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.SpellChecker.Library
{
    public class BkNode : Dictionary<int, BkNode>
    {
        public string Word { get; set; }
    }


    public class BKTree
    {
        public int Tolerance { get; set; }
        public BkNode root = null;

        public void Reset()
        {
            root = null;
        }

        public void AddWord(string word)
        {
            if (root == null)
            {
                root = new BkNode() { Word = word };
                return;
            }

            var node = root;
            var dist = GetLevenshteinDistance(node.Word, word);

            while (node.ContainsKey(dist))
            {
                if (dist == 0)
                    return;

                node = node[dist];
                dist = GetLevenshteinDistance(node.Word, word);
            }

            node.Add(dist, new BkNode() { Word = word });
        }

        private int GetLevenshteinDistance(string left, string right)
        {
            return LevenshteinDistance.GetDistance(left, right, true);
        }

        public List<string> GetSuggestions(string word)
        {
            List<string> result = new List<string>();
            GetMatchesRecursive(root, word, result);
            return result;
        }

        private void GetMatchesRecursive(BkNode node, string word, List<string> matches)
        {
            int CurrDist = GetLevenshteinDistance(node.Word, word);

            if (CurrDist <= Tolerance)
            {
                matches.Add(node.Word);
            }

            int minDist = CurrDist - Tolerance;
            int maxDist = CurrDist + Tolerance;

            foreach (var item in node)
            {
                if (item.Key >= minDist && item.Key <= maxDist)
                {
                    GetMatchesRecursive(item.Value, word, matches);
                }
            }

        }




    }
}