using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration
{
    public class TrieNode : Dictionary<char, TrieNode>
    {
        public TrieNode Parent { get; set; }
        public Char Character { get; set; }
        public string Word { get; set; }
        public string SubWord { get; set; }
    }

    public class Trie
    {

        protected TrieNode root = new TrieNode();

        public void AddWord(string word)
        {
            var node = root;

            for (int x = 0; x < word.Length; x++)
            {
                if (!node.ContainsKey(word[x]))
                {
                    var child = new TrieNode();
                    child.Character = word[x];
                    child.Parent = node;
                    child.SubWord = word.Substring(0, x + 1);
                    node.Add(word[x], child);
                    node = child;
                }
                else
                {
                    node = node[word[x]];
                }
            }

            if(node.Word == null)
            {
                node.Word = word;
            }
        }

        public List<string> GetMatches(string word)
        {
            List<string> result = new List<string>();

            var node = root;

            for (int x = 0; x < word.Length; x++)
            {
                if (node.ContainsKey(word[x]))
                {
                    node = node[word[x]];
                }
                else
                {
                    break;
                }
            }

            if(node != null)
            {
                result.Add(node.Word);
                GetSuffixRecursive(node, result);
            }

            return result;
        }

        protected void GetSuffixRecursive(TrieNode node, List<string> result)
        {
            foreach (var item in node.Values)
            {
                if (item.Word != null)
                {
                    result.Add(item.Word);
                }

                GetSuffixRecursive(item, result);
            }
        }

    }
}
