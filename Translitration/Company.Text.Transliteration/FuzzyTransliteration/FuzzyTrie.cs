using Company.Text.Transliteration.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration.FuzzyTransliteration
{

    public class FuzzyTrie : Trie
    {
        private const string _vowels = "aeiou";
        private const string _acceptableCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";

        public FuzzyCharacterMapInfo[] GetResolvedCharacters(string english, int currIndex, int prevIndex)
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


        private FuzzyCharacterMapInfo[] GetExactMatchingCharacters(CharacterToken curr, CharacterToken prev, CharacterToken next)
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
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        // english to urdu vowel compensation. Some compounds need doubles in english but doubles
                        // in english are just 'shad' on single word so we need to add vowel in the 2 characters.
                        // such as chharam etc.
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                case 'a':
                    if (currIsFirst)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // 1-1 mapping for such as 'ap'
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'آ' }, Backspaces = 0 },
                            // 1-1 mapping such as 'ab'
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // 1-1 mapping such as 'alm'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'a' && prevIsFirst)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // complex join for such as 'aam'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'آ' }, Backspaces = 0 },
                            // complex join for such as 'aam'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع', 'ا' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // 1-1 mapping for 'bap'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // 1-1 mapping for 'race'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            // 1-1 mapping for 'mualim'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // 1-1 mapping for 'mamla'
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ع', 'ا' }, Backspaces = 0 },
                            // empty for vowel
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // 1-1 mapping for 'gadha'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // 1-1 mapping for 'shama'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // 1-1 mapping for 'balla'
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 }
                        };
                    }

                case 'b':
                    return new FuzzyCharacterMapInfo[] {
                        // 1-1 mapping for 'abr'
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ب' }, Backspaces = 0 }
                    };

                case 'c':
                    return new FuzzyCharacterMapInfo[] {
                        // 1-1 mapping for 'cup'
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ک' }, Backspaces = 0 },
                        // 1-1 mapping for 'race'
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'س' }, Backspaces = 0 },
                        // 1-1 mapping for 'bhece' (very loose but probable)
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ث' }, Backspaces = 0 },
                        // 1-1 mapping for 'khabece' (very loose but probable)
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ص' }, Backspaces = 0 }
                    };

                case 'd':
                    return new FuzzyCharacterMapInfo[] {
                        // 1-1 mapping for 'daal'
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'د' }, Backspaces = 0 },
                        // 1-1 mapping for 'daal'
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ڈ' }, Backspaces = 0 }
                    };

                case 'e':
                    if (currIsFirst)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // ehtajaj
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // qemat
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            // pae
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ے' }, Backspaces = 0 },
                            //muelim
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // kutte
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ے' }, Backspaces = 0 },
                            // pae
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ئ', 'ے' }, Backspaces = 0 },
                            // je
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo() { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }

                case 'f':
                    return new FuzzyCharacterMapInfo[] {
                        // fail
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ف' }, Backspaces = 0 }
                    };

                case 'g': return new FuzzyCharacterMapInfo[] {
                    new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'گ' }, Backspaces = 0 },
                    new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'غ'  }, Backspaces = 0 }
                };

                case 'h':
                    if (prevChar == 'c')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'چ'  }, Backspaces = 1 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'k')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'خ'  }, Backspaces = 1 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 's')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ش'  }, Backspaces = 1 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'g')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'غ'  }, Backspaces = 1 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'p')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ف' }, Backspaces = 1 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ہ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ھ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ح' }, Backspaces = 0 }
                        };
                    }

                case 'i':
                    if (currIsFirst)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'آ', 'ئ' }, Backspaces = 0 },
                        };
                    }
                    else if (prevChar == 'c')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ش' }, Backspaces = 1 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی'  }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    if (prevChar == 'a')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ', 'ی' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی'  }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // sied
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // fail
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            // file
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا', 'ئ' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ', 'ی' }, Backspaces = 0 }
                        };
                    }

                case 'j':
                    return new FuzzyCharacterMapInfo[] {
                        // jahaaz
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ج' }, Backspaces = 0 }
                    };

                case 'k':
                    return new FuzzyCharacterMapInfo[] {
                        // kutta
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ک' }, Backspaces = 0 }
                    };

                case 'l':
                    return new FuzzyCharacterMapInfo[] {
                        // khail
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ل' }, Backspaces = 0 }
                    };

                case 'm':
                    return new FuzzyCharacterMapInfo[] {
                        // mali
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'م' }, Backspaces = 0 }
                    };

                case 'n':
                    return new FuzzyCharacterMapInfo[] {
                        // banjara
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ن' }, Backspaces = 0 },
                        // kahan
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ں' }, Backspaces = 0 }
                    };

                case 'o':
                    if (currIsFirst)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // oktana
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // omar
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // oho
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا', 'و' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'a')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // gao
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ؤ' }, Backspaces = 0 }
                        };
                    }
                    else if (prevChar == 'w' || prevChar == 'v')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // howi
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 },
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // khlona
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 }
                        };
                    }

                case 'p':
                    return new FuzzyCharacterMapInfo[] {
                        // pakistan
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'پ' }, Backspaces = 0 }
                    };

                case 'q':
                    return new FuzzyCharacterMapInfo[] {
                        // qianchi
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ق' }, Backspaces = 0 }
                    };

                case 'r':
                    if (currIsFirst)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // rasta
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ر' }, Backspaces = 0 }
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // gulehri
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ر' }, Backspaces = 0 },
                            // pahaar
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ڑ' }, Backspaces = 0 }
                        };
                    }

                case 's':
                    return new FuzzyCharacterMapInfo[] {
                        // sasta
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'س' }, Backspaces = 0 },
                        // gutter
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ث' }, Backspaces = 0 },
                        // masdar
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ص' }, Backspaces = 0 }
                    };

                case 't':
                    return new FuzzyCharacterMapInfo[] {
                        //titlee
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ت' }, Backspaces = 0 },
                        // gitaar
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ٹ' }, Backspaces = 0 },
                        // galat
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ط' }, Backspaces = 0 }
                    };

                case 'u':
                    if (currIsFirst)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // utarna
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا' }, Backspaces = 0 },
                            // umrah
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ع' }, Backspaces = 0 },
                            // ulaad
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ا', 'و' }, Backspaces = 0 }
                        };
                    }
                    else if (!currIsLast)
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // gustakh
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی', 'و' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 },
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            //bhaloo
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی', 'و' }, Backspaces = 0 },
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 },
                        };
                    }

                case 'v':
                case 'w':
                    if (prevChar == 'o')
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // howi
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { '\x0' }, Backspaces = 0 },
                        };
                    }
                    else
                    {
                        return new FuzzyCharacterMapInfo[] {
                            // ganwaar
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'و' }, Backspaces = 0 },
                            // bawan
                            new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'و', 'و' }, Backspaces = 0 }
                        };
                    }

                case 'x':
                    return new FuzzyCharacterMapInfo[] {
                        // zeexan
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ش' }, Backspaces = 0 }
                    };

                case 'y':
                    return new FuzzyCharacterMapInfo[] {
                        // kya
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ی' }, Backspaces = 0 },
                        // kiay
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ے' }, Backspaces = 0 },
                        // howay
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ئ' , 'ے' }, Backspaces = 0 },

                    };

                case 'z':
                    return new FuzzyCharacterMapInfo[] {
                        // zubaan
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ز' }, Backspaces = 0 },
                        // zkheera
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ذ' }, Backspaces = 0 },
                        // zaeef
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ض' }, Backspaces = 0 },
                        // zaroof
                        new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { 'ظ' }, Backspaces = 0 }
                    };

            }

            return new FuzzyCharacterMapInfo[] {
                new FuzzyCharacterMapInfo { English = currChar, Urdu = new char[] { currChar }, Backspaces = 0 }
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

                        FuzzyCharacterMapInfo[] fuzzyChars = GetResolvedCharacters(english, currentIndex, previousIndex);

                        foreach (FuzzyCharacterMapInfo fc in fuzzyChars)
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