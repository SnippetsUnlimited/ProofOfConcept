using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAPIForSpeechRecognitionUsingFLAC
{
    public class GoogleAPIResult
    {
        public int status { get; set; }
        public string id { get; set; }
        public List<Hypotheses> hypotheses { get; set; }
    }

    public class Hypotheses
    {
        public string utterance { get; set; }
        public decimal confidence { get; set; }

    }
}
