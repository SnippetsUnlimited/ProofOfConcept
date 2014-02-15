using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration.FuzzyTransliteration
{

    public class UrduTrie : Trie
    {
        private const string _vowels = "aeiou";
        private const string _acceptableCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";

        public CharacterMapInfo[] GetResolvedCharacters(string english, int currIndex, int prevIndex)
        {
            CharacterToken curr = null;
            CharacterToken prev = null;
            CharacterToken next = null;

            curr = new CharacterToken()
            {
                Value = english[currIndex],
                IsFirst = currIndex == 0,
                IsLast = english.Length == currIndex + 1,
                IsVowel = _vowels.Contains(english[currIndex])
            };

            if (currIndex > 0)
            {
                prev = new CharacterToken()
                {
                    Value = (prevIndex > -1) ? english[prevIndex] : '\x0',
                    IsFirst = prevIndex == 0,
                    IsLast = false,
                    IsVowel = _vowels.Contains(english[currIndex - 1])
                };
            }

            if (currIndex + 1 < english.Length)
            {
                next = new CharacterToken()
                {
                    Value = english[currIndex + 1],
                    IsFirst = false,
                    IsLast = english.Length == currIndex + 2,
                    IsVowel = _vowels.Contains(english[currIndex + 1])
                };
            }

            return GetExactMatchingCharacters(curr, prev, next);
        }


        private CharacterMapInfo[] GetExactMatchingCharacters(CharacterToken curr, CharacterToken prev, CharacterToken next)
        {
            char currChar = curr.Value;
            char prevChar = (prev != null) ? prev.Value : '\x0';
            bool currIsFirst = curr.IsFirst;
            bool currIsLast = curr.IsLast;
            bool prevIsFirst = (prev != null) ? prev.IsFirst : false;

            switch (currChar)
            {
                case '0':
                    if (currIsFirst)
                    {
                        // this case is not used yet.
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        // english to urdu vowel compensation. Some compounds need doubles in english but doubles
                        // in english are just 'shad' on single word so we need to add vowel in the 2 characters.
                        // such as chharam etc.
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                case 'a':
                    if (currIsFirst)
                    {
                        return new CharacterMapInfo[] {
                            // 1-1 mapping for such as 'ap'
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'آ' }, Backspaces = 0 },
                            // 1-1 mapping such as 'ab'
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // 1-1 mapping such as 'alm'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'a' && prevIsFirst)
                    {
                        return new CharacterMapInfo[] {
                            // complex join for such as 'aam'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'آ' }, Backspaces = 0 },
                            // complex join for such as 'aam'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع', 'ا' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new CharacterMapInfo[] {
                            // 1-1 mapping for 'bap'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // 1-1 mapping for 'race'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            // 1-1 mapping for 'mualim'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // 1-1 mapping for 'mamla'
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ع', 'ا' }, Backspaces = 0 },
                            // empty for vowel
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            // 1-1 mapping for 'gadha'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // 1-1 mapping for 'shama'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // 1-1 mapping for 'balla'
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 }
                        };
                    }

                case 'b':
                    return new CharacterMapInfo[] {
                        // 1-1 mapping for 'abr'
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ب' }, Backspaces = 0 }
                    };

                case 'c':
                    return new CharacterMapInfo[] {
                        // 1-1 mapping for 'cup'
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ک' }, Backspaces = 0 },
                        // 1-1 mapping for 'race'
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'س' }, Backspaces = 0 },
                        // 1-1 mapping for 'bhece' (very loose but probable)
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ث' }, Backspaces = 0 },
                        // 1-1 mapping for 'khabece' (very loose but probable)
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ص' }, Backspaces = 0 }
                    };

                case 'd':
                    return new CharacterMapInfo[] {
                        // 1-1 mapping for 'daal'
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'د' }, Backspaces = 0 },
                        // 1-1 mapping for 'daal'
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ڈ' }, Backspaces = 0 }
                    };

                case 'e':
                    if (currIsFirst)
                    {
                        return new CharacterMapInfo[] {
                            // ehtajaj
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new CharacterMapInfo[] {
                            // qemat
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            // pae
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ے' }, Backspaces = 0 },
                            //muelim
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            // kutte
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ے' }, Backspaces = 0 },
                            // pae
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ئ', 'ے' }, Backspaces = 0 },
                            // je
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            new CharacterMapInfo() { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }

                case 'f':
                    return new CharacterMapInfo[] {
                        // fail
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ف' }, Backspaces = 0 }
                    };

                case 'g': return new CharacterMapInfo[] {
                    new CharacterMapInfo { English = currChar, Urdu = new char[] { 'گ' }, Backspaces = 0 },
                    new CharacterMapInfo { English = currChar, Urdu = new char[] { 'غ'  }, Backspaces = 0 }
                };

                case 'h':
                    if (prevChar == 'c')
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'چ'  }, Backspaces = 1 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'k')
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'خ'  }, Backspaces = 1 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 's')
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ش'  }, Backspaces = 1 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'g')
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'غ'  }, Backspaces = 1 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'p')
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ف' }, Backspaces = 1 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }

                case 'i':
                    if (currIsFirst)
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'آ', 'ئ' }, Backspaces = 0 },
                        };
                    }
                    else if (prevChar == 'c')
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ش' }, Backspaces = 1 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی'  }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    if (prevChar == 'a')
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ', 'ی' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی'  }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new CharacterMapInfo[] {
                            // sied
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // fail
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            // file
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا', 'ئ' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ', 'ی' }, Backspaces = 0 }
                        };
                    }

                case 'j':
                    return new CharacterMapInfo[] {
                        // jahaaz
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ج' }, Backspaces = 0 }
                    };

                case 'k':
                    return new CharacterMapInfo[] {
                        // kutta
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ک' }, Backspaces = 0 }
                    };

                case 'l':
                    return new CharacterMapInfo[] {
                        // khail
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ل' }, Backspaces = 0 }
                    };

                case 'm':
                    return new CharacterMapInfo[] {
                        // mali
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'م' }, Backspaces = 0 }
                    };

                case 'n':
                    return new CharacterMapInfo[] {
                        // banjara
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ن' }, Backspaces = 0 },
                        // kahan
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ں' }, Backspaces = 0 }
                    };

                case 'o':
                    if (currIsFirst)
                    {
                        return new CharacterMapInfo[] {
                            // oktana
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // omar
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // oho
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا', 'و' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'a')
                    {
                        return new CharacterMapInfo[] {
                            // gao
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ؤ' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'w' || prevChar == 'v')
                    {
                        return new CharacterMapInfo[] {
                            // howi
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 },
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            // khlona
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 }
                        };
                    }

                case 'p':
                    return new CharacterMapInfo[] {
                        // pakistan
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'پ' }, Backspaces = 0 }
                    };

                case 'q':
                    return new CharacterMapInfo[] {
                        // qianchi
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ق' }, Backspaces = 0 }
                    };

                case 'r':
                    if (currIsFirst)
                    {
                        return new CharacterMapInfo[] {
                            // rasta
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ر' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            // gulehri
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ر' }, Backspaces = 0 },
                            // pahaar
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ڑ' }, Backspaces = 0 }
                        };
                    }

                case 's':
                    return new CharacterMapInfo[] {
                        // sasta
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'س' }, Backspaces = 0 },
                        // gutter
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ث' }, Backspaces = 0 },
                        // masdar
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ص' }, Backspaces = 0 }
                    };

                case 't':
                    return new CharacterMapInfo[] {
                        //titlee
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ت' }, Backspaces = 0 },
                        // gitaar
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ٹ' }, Backspaces = 0 },
                        // galat
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ط' }, Backspaces = 0 }
                    };

                case 'u':
                    if (currIsFirst)
                    {
                        return new CharacterMapInfo[] {
                            // utarna
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // umrah
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // ulaad
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ا', 'و' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new CharacterMapInfo[] {
                            // gustakh
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی', 'و' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 },
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            //bhaloo
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی', 'و' }, Backspaces = 0 },
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 },
                        };
                    }

                case 'v':
                case 'w':
                    if (prevChar == 'o')
                    {
                        return new CharacterMapInfo[] {
                            // howi
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 },
                        };
                    }
                    else
                    {
                        return new CharacterMapInfo[] {
                            // ganwaar
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 },
                            // bawan
                            new CharacterMapInfo { English = currChar, Urdu = new char[] { 'و', 'و' }, Backspaces = 0 }
                        };
                    }

                case 'x':
                    return new CharacterMapInfo[] {
                        // zeexan
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ش' }, Backspaces = 0 }
                    };

                case 'y':
                    return new CharacterMapInfo[] {
                        // kya
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                        // kiay
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ے' }, Backspaces = 0 },
                        // howay
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ' , 'ے' }, Backspaces = 0 },

                    };

                case 'z':
                    return new CharacterMapInfo[] {
                        // zubaan
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ز' }, Backspaces = 0 },
                        // zkheera
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ذ' }, Backspaces = 0 },
                        // zaeef
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ض' }, Backspaces = 0 },
                        // zaroof
                        new CharacterMapInfo { English = currChar, Urdu = new char[] { 'ظ' }, Backspaces = 0 }
                    };

            }

            return new CharacterMapInfo[] {
                new CharacterMapInfo { English = currChar, Urdu = new char[] { currChar }, Backspaces = 0 }
            };
        }

        public List<string> GetFuzzyMatches(string english)
        {
            for (int x = 0; x < english.Length; x++)
            {
                if (char.IsControl(english[x]))
                {
                    english = english.Remove(x--, 1);
                }
            }

            List<string> result = new List<string>();
            result.Add(english);
            GetFuzzy(english, result);

            return result;
        }

        public class ParseState
        {
            public TrieNode Node;
            public int PreviousIndex;
            public char[] MissedStack = new char[10];
            public int MissedIndex = -1;
        }

        private void GetFuzzy(string english, List<string> result)
        {
            List<ParseState> stateList = new List<ParseState>();
            stateList.Add(new ParseState() { Node = root, PreviousIndex = -2 });

            if (english.Length > 0)
            {
                for (int x = 0; x < english.Length; x++)
                {
                    ParseState[] states = stateList.ToArray();

                    foreach (ParseState state in states)
                    {
                        stateList.RemoveAll(item => item.Node == state.Node || item == null);

                        int currentIndex = x;
                        int previousIndex = state.PreviousIndex;

                        char currChar = english[currentIndex];

                        CharacterMapInfo[] fuzzyChars = GetResolvedCharacters(english, currentIndex, previousIndex);

                        foreach (CharacterMapInfo fc in fuzzyChars)
                        {
                            TrieNode newNode = state.Node;

                            // if its an empty character (no matter what the backspace is) or is with backspace > 0 then
                            // process the character. Else process all 0 backspace non empty characters
                            if (fc.Backspaces > 0)
                            {
                                int bsp = fc.Backspaces;

                                while (state.MissedIndex > -1)
                                {
                                    state.MissedStack[state.MissedIndex--] = '\x0';
                                    bsp--;
                                }

                                // backspace tree
                                while (bsp > 0)
                                {
                                    newNode = newNode.Parent;
                                    bsp--;
                                }
                            }

                            ParseState charState = new ParseState();
                            charState.MissedIndex = state.MissedIndex;
                            charState.MissedStack = (char[])state.MissedStack.Clone();

                            // if empty then ignore the character and keep the previous index.
                            if (fc.Urdu[0] == '\x0')
                            {
                                int newPreviousIndex = currentIndex - fc.Backspaces - 1;

                                charState.PreviousIndex = newPreviousIndex;
                                charState.Node = newNode;
                                stateList.Add(charState);
                            }
                            else
                            {
                                TrieNode nx = newNode;

                                for (int t = 0; t < fc.Urdu.Length; t++)
                                {
                                    if (charState.MissedIndex < 0 && nx.ContainsKey(fc.Urdu[t]))
                                    {
                                        nx = nx[fc.Urdu[t]];
                                    }
                                    else
                                    {
                                        charState.MissedStack[++charState.MissedIndex] = fc.Urdu[t];
                                    }
                                }

                                if (charState.MissedIndex < 5)
                                {
                                    charState.PreviousIndex = currentIndex;
                                    charState.Node = nx;
                                    stateList.Add(charState);
                                }
                            }

                        }
                    }
                }

                foreach (ParseState i in stateList)
                {
                    string word = i.Node.Word;
                    if (word != null && i.MissedIndex < 0 && !result.Contains(word))
                    {
                        result.Add(i.Node.Word);
                    }
                    //base.GetMatchesRecursive(i.Node, result);
                }
            }
        }
    }
}