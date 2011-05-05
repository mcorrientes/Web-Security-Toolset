using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace usertools.WebFuzzer.Components.Generators
{
    [Serializable()]
    public class CharacterGenerator : IGenerator
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int StartCharacter;
        public int StopCharacter;
        public int Increment;
        public Encodings Encoding;

        public CharacterGenerator()
        {
            name = string.Empty;
            StartCharacter = 0;
            StopCharacter = 0;
            Increment = 1;
            Encoding = Encodings.None;
        }
    }
}
