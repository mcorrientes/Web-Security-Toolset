using System;
using System.Collections.Generic;
using System.Text;


namespace usertools.WebFuzzer
{   
    interface IGenerator
    {
        string Name
        {
            get;
            set;
        }
    }
}
