using System;
using System.Collections.Generic;
using System.Text;
using usertools.WebFuzzer.Components.Generators;
using System.IO;

namespace usertools.WebFuzzer
{
    class RequestGenerator
    {
        private List<IGenerator> Generators;

        public RequestGenerator(List<IGenerator> Generators)
        {
            this.Generators = Generators;
        }

        public List<string> GenerateRequestList(string URL)
        {
            List<string> NewList = new List<string>();
            NewList.Add(URL);


            for (int i = 0; i < Generators.Count; i++)
            {
                if (!URL.Contains("{" + Generators[i].Name + "}"))
                    continue;

                NewList = BuildList(Generators[i], NewList);
            }

            return NewList;
        }

        private List<string> BuildList(IGenerator Generator, List<string> List)
        {
            List<string> OldList = List;
            List<string> NewList = new List<string>();

            for (int i = 0; i < OldList.Count; )
            {
                string OldValue = List[i];
                List.RemoveAt(i);

                if (Generator.GetType() == typeof(CharacterGenerator))
                {
                    CharacterGenerator characterGenerator = (CharacterGenerator)Generator;
                    NewList.AddRange(BuildCharacters(characterGenerator, OldValue));
                }
                else if (Generator.GetType() == typeof(CharacterRepeater))
                {
                    CharacterRepeater characterRepeater = (CharacterRepeater)Generator;
                    NewList.AddRange(BuildCharacterRepeats(characterRepeater, OldValue));
                }
                else if (Generator.GetType() == typeof(FileGenerator))
                {
                    FileGenerator fileGenerator = (FileGenerator)Generator;
                    NewList.AddRange(BuildFileString(fileGenerator, OldValue));
                }
                else if (Generator.GetType() == typeof(NumberGenerator))
                {
                    NumberGenerator numberGenerator = (NumberGenerator)Generator;
                    NewList.AddRange(BuildNumbers(numberGenerator, OldValue));
                }
                else if (Generator.GetType() == typeof(RandomStringGenerator))
                {
                    RandomStringGenerator randomStringGenerator = (RandomStringGenerator)Generator;
                    NewList.AddRange(BuildRandomStrings(randomStringGenerator, OldValue));
                }
                else if (Generator.GetType() == typeof(StringGenerator))
                {
                    StringGenerator stringGenerator = (StringGenerator)Generator;
                    NewList.AddRange(BuildStrings(stringGenerator, OldValue, ""));
                }
            }
            return NewList;
        }



        private List<string> BuildCharacters(CharacterGenerator Generator, string Text)
        {
            List<string> fuzzed = new List<string>();
            for (int i = Generator.StartCharacter; i <= Generator.StopCharacter; i += Generator.Increment)
            {
                char converted = Convert.ToChar(i);
                fuzzed.Add(Text.Replace("{" + Generator.Name + "}", converted.ToString()));
            }
            return fuzzed;
        }

        private List<string> BuildCharacterRepeats(CharacterRepeater Generator, string Text)
        {
            List<string> fuzzed = new List<string>();
            for (int i = Generator.InitialCount; i <= Generator.FinalCount; i += Generator.Increment)
            {
                string multi = Multiply(Generator.Character, i);
                fuzzed.Add(Text.Replace("{" + Generator.Name + "}", multi));
            }
            return fuzzed;
        }

        private string Multiply(string multi, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multi.Length * multiplier);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(multi);
            }
            return sb.ToString();
        }

        private List<string> BuildFileString(FileGenerator Generator, string Text)
        {
            List<string> fuzzed = new List<string>();
            string[] file = File.ReadAllLines(Generator.FilePath);
            for (int i = 0; i < file.Length; i++)
            {
                fuzzed.Add(Text.Replace("{" + Generator.Name + "}", file[i]));
            }
            return fuzzed;
        }

        private List<string> BuildNumbers(NumberGenerator Generator, string Text)
        {
            List<string> Fuzzed = new List<string>();
            for (int i = Generator.StartNumber; i <= Generator.StopNumber; i += Generator.Increment)
                Fuzzed.Add(Text.Replace("{" + Generator.Name + "}", i.ToString()));

            return Fuzzed;
        }

        private List<string> BuildRandomStrings(RandomStringGenerator Generator, string Text)
        {
            List<string> Fuzzed = new List<string>();
            string finaltext = string.Empty;

            for (int iRows = 1; iRows <= Generator.MaximumStrings; iRows++)
            {
                char zuletzt = '*';
                List<Char> UsedChars = new List<char>();
                for (int iChar = 0; iChar < Generator.StringLength; iChar++)
                {
                    Random zahl = new Random();
                    Char NeuBuchstabe = Generator.CharacterSet[zahl.Next(0, Generator.CharacterSet.Length - 1)];
                    if (!Generator.AllowRepetitions)
                        if (UsedChars.Contains(NeuBuchstabe))
                        {
                            iChar--;
                            continue;
                        }
                    finaltext += NeuBuchstabe.ToString();
                    zuletzt = NeuBuchstabe;
                    UsedChars.Add(zuletzt);
                }
                Fuzzed.Add(Text.Replace("{" + Generator.Name + "}", finaltext));
            }

            return new List<string>();
        }

        private List<string> BuildStrings(StringGenerator Generator, string URL, string Text)
        {
            List<string> Fuzzed = new List<string>();
            List<char> Used = new List<char>();

            for (int i = 0; i <= Generator.CharacterSet.Length-1; i++)
            {
                Char NewChar =  Generator.CharacterSet[i];
                if (!Generator.AllowRepetitions)
                    if (Text.Contains(NewChar.ToString()))
                        continue;

                string NewText = Text +NewChar.ToString();
                if (Text.Length + 1 < Generator.StringLength)
                    Fuzzed.AddRange(BuildStrings(Generator, URL, NewText));
                if (NewText.Length == Generator.StringLength)
                    Fuzzed.Add(URL.Replace("{" + Generator.Name + "}", NewText));
            }

            return Fuzzed;
        }



        public void AddNumberRequests(List<string> RequestList)
        {
            List<string> AddRequestList = new List<string>();

            foreach (string Request in RequestList)
                for (int i = 0; i < 40615; i++)
                    AddRequestList.Add(Request.Replace("{numbers}", i.ToString()));

            RequestList.AddRange(AddRequestList);
        }
    }
}
