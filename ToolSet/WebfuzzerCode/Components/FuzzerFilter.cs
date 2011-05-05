using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer
{
    [Serializable()]
    public class FuzzerFilter
    {
        public enum FilterTypes
        {
            Include,
            Exclude
        }
        public enum ConditionTypes{
            ResponseHTML,
            ResponseHeaders,
            ResponseStatusCode
        }

        public string Name;
        public FilterTypes FilterType;
        public ConditionTypes ConditionType;
        public string ConditionValue;

        public FuzzerFilter()
        {
            Name = string.Empty;
            FilterType = FilterTypes.Include;
            ConditionType = ConditionTypes.ResponseHTML;
            ConditionValue = string.Empty;
        }
    }
}
