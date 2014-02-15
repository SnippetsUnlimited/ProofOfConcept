using Company.Text.Transliteration.StrictTranslitration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Text.Transliteration.StrictTranslitration
{
    public class DataItem : Tuple<string, StrictCharacterMapInfo>
    {
        public DataItem(string key, StrictCharacterMapInfo value)
            : base(key, value)
        {
        }
    }
}
