using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer.Components.Generators
{
   [Serializable()]
   public class FileGenerator : IGenerator
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FilePath;
        public Encodings Encoding;

        public FileGenerator()
        {
            name = string.Empty;
            FilePath = string.Empty;
            Encoding = Encodings.None;
        }
    }
}
