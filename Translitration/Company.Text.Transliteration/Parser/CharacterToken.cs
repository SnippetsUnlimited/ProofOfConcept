using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration.Parser
{
    public class CharacterToken
    {
        public char Value = '\x0';
        public bool IsVowel = false;
        public bool IsGenericVowel = false;
        public bool IsFirst = false;
        public bool IsLast = false;
        public bool IsInvalidCharacter = false;
    }
}
