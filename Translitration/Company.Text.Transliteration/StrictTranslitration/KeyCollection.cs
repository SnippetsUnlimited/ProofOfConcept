using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration.StrictTranslitration
{
    public class KeyCollection
    {
        private List<KeyInfo> Items = new List<KeyInfo>();

        public void Add(KeyInfo item)
        {
            Items.Add(item);
        }

        public static bool Compare(char[] left, char[] right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }
            else if (left.Length == right.Length)
            {
                for (int x = 0; x < left.Length; x++)
                {
                    if (left[x] != right.Length)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool Equals(object o)
        {
            char[] left = this.Items.Select(x => x.English).ToArray();

            if (o is char[])
            {
                return KeyCollection.Compare(left, o as char[]);
            }
            else if (o is KeyCollection)
            {
                char[] right = (o as KeyCollection).Items.Select(x => x.English).ToArray();
                return KeyCollection.Compare(left, right);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator==(char[] english, KeyCollection right)
        {
            char[] o = (right as KeyCollection).Items.Select(x => x.English).ToArray();
            return KeyCollection.Compare(english, o);
        }

        public static bool operator !=(char[] english, KeyCollection right)
        {
            char[] o = (right as KeyCollection).Items.Select(x => x.English).ToArray();
            return !KeyCollection.Compare(english, o);
        }

        public int KeyCount
        {
            get
            {
                return Items.Count;        
            }
        }

        public KeyInfo this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void RemoveLast()
        {
            Items.RemoveAt(Items.Count - 1);
        }

        public void RemoveAt(int index)
        {
            int curr = index;

            // if this character resulted a merge (ch, kh, sh, gh) then set the backspace to 0 for next.
            while (Items.Count - 1 > curr && Items[curr + 1].BackSpace > 0)
            {
                Items[curr + 1].BackSpace = 0;
            }

            Items.RemoveAt(index);
        }

        public string ToEnglishString()
        {
            return ToEnglishString(Items.Count);
        }

        public string GetUrduString()
        {
            return ToUrduString(Items.Count);
        }

        public string ToEnglishString(int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < length; x++)
            {
                sb.Append(Items[x].English);
            }

            string eng = sb.ToString();
            return eng;
        }

        public string ToUrduString(int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int x = 0; x < length; x++)
            {
                ProcessKey(sb, Items[x]);
            }

            return sb.ToString();
        }

        public string GetUrduStringPreview(string prefix, KeyInfo key)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(prefix);

            ProcessKey(sb, key);

            return sb.ToString();
        }

        private void ProcessKey(StringBuilder sb, KeyInfo key)
        {
            int bksp = key.BackSpace;

            if (sb.Length >= bksp && bksp > 0)
            {
                sb.Remove(sb.Length - bksp, bksp);
            }

            sb.Append(key.Urdu);
        }

        public static StrictCharacterMapInfo[] ResolveCharacter(char current, char previous)
        {
            switch (current)
            {
                case 'a':
                    if (previous == 'a')
                    {
                        return new StrictCharacterMapInfo[] {
                            new StrictCharacterMapInfo() { Backspaces = 1, English = current, Urdu = 'آ' }
                        };
                    }
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ا' }
                    };

                case 'b':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ب' }
                    };

                case 'c':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ک' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'س' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ث' }
                    };

                case 'd':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'د' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ڈ' }
                    };

                case 'e':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ع' },
                    };

                case 'f':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ف' }
                    };

                case 'g':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'گ' }
                    };

                case 'h':
                    if (previous == 'c')
                    {
                        return new StrictCharacterMapInfo[] {
                            new StrictCharacterMapInfo() { Backspaces = 1, English = current, Urdu = 'چ' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ہ' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ح' }
                        };
                    }
                    if (previous == 'k')
                    {
                        return new StrictCharacterMapInfo[] {
                            new StrictCharacterMapInfo() { Backspaces = 1, English = current, Urdu = 'خ' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ہ' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ح' }
                        };
                    }
                    if (previous == 'g')
                    {
                        return new StrictCharacterMapInfo[] {
                            new StrictCharacterMapInfo() { Backspaces = 1, English = current, Urdu = 'غ' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ہ' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ح' }
                        };
                    }
                    if (previous == 's')
                    {
                        return new StrictCharacterMapInfo[] {
                            new StrictCharacterMapInfo() { Backspaces = 1, English = current, Urdu = 'ش' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ہ' },
                            new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ح' }
                        };
                    }
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ہ' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ح' }
                    };

                case 'i':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ی' }
                    };

                case 'j':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ج' }
                    };

                case 'k':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ک' }
                    };

                case 'l':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ل' }
                    };

                case 'm':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'م' }
                    };

                case 'n':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ن' }
                    };

                case 'o':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'و' }
                    };

                case 'p':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'پ' }
                    };

                case 'q':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ق' }
                    };

                case 'r':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ر' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ڑ' }
                    };

                case 's':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'س' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ص' }
                    };

                case 't':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ت' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ٹ' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ط' }
                    };

                case 'u':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'و' }
                    };

                case 'v':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'و' }
                    };

                case 'w':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'و' }
                    };

                case 'x':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ش' }
                    };

                case 'y':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ے' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ی' }
                    };

                case 'z':
                    return new StrictCharacterMapInfo[] {
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ز' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ذ' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ض' },
                        new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = 'ظ' }
                    };
            }

            return new StrictCharacterMapInfo[] {
                new StrictCharacterMapInfo() { Backspaces = 0, English = current, Urdu = current }
            };
        }

    }
}