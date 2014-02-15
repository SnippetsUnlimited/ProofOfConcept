using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration.StrictTranslitration
{
    public class InputManager
    {
        KeyCollection keycollection = new KeyCollection();
        SearchResult[] suggestions = new SearchResult[0];


        public void ProcessInput(char newChar, bool useSuggestions, int suggestionCode)
        {
            int suggestionId = 0;

            if (useSuggestions && suggestionCode > -1 && suggestionCode < suggestions.Length)
            {
                suggestionId = suggestionCode;
            }

            List<string> ret = new List<string>();

            char prevChar = (char)0;


            if (newChar == '\b')
            {
                if (keycollection.KeyCount > 0)
                {
                    KeyInfo key = keycollection[keycollection.KeyCount - 1];
                    keycollection.RemoveLast();

                    newChar = key.English;

                    if (keycollection.KeyCount > 0)
                    {
                        prevChar = keycollection[keycollection.KeyCount - 1].English;
                    }
                }
                else
                {
                    newChar = (char)0;
                }
            }
            else
            {
                if (suggestions.Length > 0)
                {
                    StrictCharacterMapInfo resChar = suggestions[suggestionId].Item2;
                    prevChar = resChar.English;
                    keycollection.Add(new KeyInfo() { BackSpace = resChar.Backspaces, English = resChar.English, Urdu = resChar.Urdu });
                }
            }

            // Reset
            suggestions = new SearchResult[0];


            if (newChar != 0)
            {
                StrictCharacterMapInfo[] result = KeyCollection.ResolveCharacter(newChar, prevChar);
                string prefix = keycollection.ToUrduString(keycollection.KeyCount);

                if (!useSuggestions)
                {
                    KeyInfo key = new KeyInfo() { BackSpace = result[0].Backspaces, English = result[0].English, Urdu = result[0].Urdu };
                    suggestions = new SearchResult[] { new SearchResult(keycollection.GetUrduStringPreview(prefix, key), result[0]) };
                }
                else
                {
                    suggestions = new SearchResult[result.Length];

                    for (int x = 0; x < result.Length; x++)
                    {
                        var key = new KeyInfo() { BackSpace = result[x].Backspaces, English = result[x].English, Urdu = result[x].Urdu };
                        suggestions[x] = new SearchResult(keycollection.GetUrduStringPreview(prefix, key), result[x]);
                    }
                }
            }

        }

        public Dictionary<int, string> GetSuggestions()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            for (int x = 0; x < suggestions.Length; x++)
            {
                result.Add(x, suggestions[x].Item1);
            }

            return result;
        }
    }
}
