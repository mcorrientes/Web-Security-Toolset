using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer.Components.Generators
{
    [Serializable()]
    public class RandomStringGenerator : IGenerator
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
        public int MaximumStrings;
        public Encodings Encoding;

        public RandomStringGenerator()
        {
            name = string.Empty;
            StringLength = 0;
            CharacterSet = string.Empty;
            AllowRepetitions = false;
            MaximumStrings = 0;
            Encoding = Encodings.None;
        }
    }
}
