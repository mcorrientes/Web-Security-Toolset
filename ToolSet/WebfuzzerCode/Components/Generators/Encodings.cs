using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer.Components.Generators
{
    public enum Encodings
    {
        None,
        Base64,
        URL,
        URLComplete,
        MD5
    }
    class GeneratorEncoding
    {
        public static Encodings GetEncoding(int Index)
        {
            if (Index == 1)
                return Encodings.URL;
            else if (Index == 2)
                return Encodings.URLComplete;
            else if (Index == 3)
                return Encodings.Base64;
            else if (Index == 4)
                return Encodings.MD5;

            return Encodings.None;
        }

        public static int ReturnEncodingIndex(Encodings encodings)
        {
            if (encodings == Encodings.URL)
                return 1;
            else if (encodings == Encodings.URLComplete)
                return 2;
            else if (encodings == Encodings.Base64)
                return 3;
            else if (encodings == Encodings.MD5)
                return 4;

            return 0;
        }
    }
}
