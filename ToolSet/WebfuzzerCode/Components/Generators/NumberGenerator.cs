using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer.Components.Generators
{
    [Serializable()]
    public class NumberGenerator : IGenerator
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int StartNumber;
        public int StopNumber;
        public int Increment;
        public Encodings Encoding;

        public NumberGenerator()
        {
            name = string.Empty;
            StartNumber = 0;
            StopNumber = 0;
            Increment = 1;
            Encoding = Encodings.None;
        }

    }
}
