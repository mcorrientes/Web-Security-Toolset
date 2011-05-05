using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.AuthenticationTester
{
    public class InputField
    {
        public enum InputTypes
        {
            Username,
            Password,
            None
        }
        public string Name;
        public string Type;
        public string Value;
        public InputTypes InputType;

        public InputField()
        {
            Name = string.Empty;
            Type = string.Empty;
            Value = string.Empty;
            InputType = InputTypes.None;
        }
    }
}
