using System;
using System.Collections.Generic;
using System.Text;

namespace ToolSet.InjectionBrowsercode.Components
{
    public class QueryModifier
    {
        private string OriginalQuery;
        private int CurrentIndex;

        private int parameterCount;
        public int ParameterCount
        {
            get { return parameterCount; }
        }

        public QueryModifier(string Query)
        {
            OriginalQuery = Query;
            CurrentIndex = 0;
            parameterCount = 0;

            for (int i = 0; i < OriginalQuery.Length; i++)
                if (OriginalQuery[i] == '=')
                    parameterCount++;
        }

        public bool NextParameter()
        {
            CurrentIndex++;
            if (CurrentIndex < parameterCount)
                return true;

            return false;
        }

        public string GetModifiedQuery(string Modify)
        {
            if (CurrentIndex >= parameterCount)
                return null;

            int CurrentAmpIndex = -1;
            if (CurrentIndex > 0)
                for (int i = 0; i < CurrentIndex; i++)
                {
                    int Index = OriginalQuery.IndexOf('&', CurrentAmpIndex + 1);
                    if (Index != -1)
                        CurrentAmpIndex = Index;
                }

            if (CurrentAmpIndex == -1)
                CurrentAmpIndex = 0;

            int EqualIndex = OriginalQuery.IndexOf('=', CurrentAmpIndex);
            if (EqualIndex == -1)
                return OriginalQuery + "=" + Modify;

            int NextAmpIndex = OriginalQuery.IndexOf('&', EqualIndex);
            if (NextAmpIndex == -1)
                return OriginalQuery.Remove(EqualIndex + 1) + Modify;
            else
                return OriginalQuery.Remove(EqualIndex + 1, NextAmpIndex - (EqualIndex + 1)).Insert(EqualIndex + 1, Modify);
        }
    }
}
