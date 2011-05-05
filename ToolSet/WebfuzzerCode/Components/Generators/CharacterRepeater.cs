using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer.Components.Generators
{
    [Serializable()]
    public class CharacterRepeater : IGenerator
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Character;
        public int InitialCount;
        public int FinalCount;
        public int Increment;
        public Encodings Encoding;

        public CharacterRepeater()
        {
            name = string.Empty;
            Character = string.Empty;
            InitialCount = 0;
            FinalCount = 0;
            Increment = 1;
            Encoding = Encodings.None;
        }
    }
}
