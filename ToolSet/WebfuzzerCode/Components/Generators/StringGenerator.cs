using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer.Components.Generators
{
    [Serializable()]
    public class StringGenerator : IGenerator
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int StringLength;
        public string CharacterSet;
        public bool AllowRepetitions;
        public Encodings Encoding;

        public StringGenerator()
        {
            name = string.Empty;
            StringLength = 0;
            CharacterSet = string.Empty;
            AllowRepetitions = false;
            Encoding = Encodings.None;
        }
    }
}
