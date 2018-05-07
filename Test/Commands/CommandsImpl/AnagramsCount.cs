using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Commands
{
    class AnagramsCount : BaseCommand
    {
        private readonly int Number = 3;
        private static readonly StringBuilder sb = new StringBuilder(
            "Two words are anagrams of each other if they both contain the same letters." + Environment.NewLine +
            "For example:" + Environment.NewLine + 
            "'abba' & 'baab' == true 'abba' & 'bbaa' == true 'abba' & 'abbba' == false" + Environment.NewLine
            );

        public override void Run()
        {
            writer.WriteHeading(GetCommandName());
            writer.WriteLine("Enter the template: ");
            string template = reader.ReadInputParameters()[0];
            writer.WriteLine("Enter the list of words to be checked separated with single space: ");
            List<string> words = reader.ReadInputParameters();
            writer.WriteLine("Result : {0}", string.Join(", ", Anagrams(template, words)));
            
        }

        private List<string> Anagrams(string template, List<string> words)
        {
            string model = String.Concat(template.OrderBy(c => c));
          
            return words.Where(w => String.Concat(w.OrderBy(c => c)).Equals(model)).ToList();
        }

        private List<string> AnagramsComplicated(string template, List<string> words)
        {
            List<string> result = new List<string>();

            foreach (string word in words)
            {
                if (word.Length != template.Length) continue;
                StringBuilder wordCopy = new StringBuilder(word);

                bool isAnagram = true;

                for (int i = 0; i < template.Length; i++)
                {
                    int index = wordCopy.ToString().IndexOf(template[i]);
                    if(index > -1)
                    {
                        wordCopy.Remove(index, 1);
                    }
                    else
                    {
                        isAnagram = false;
                        break;
                    }
                }

                if (isAnagram)
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public override void ProgramInfo()
        {
            writer.WriteLine(sb);
        }

        public override int GetProgramNumber()
        {
            return Number;
        }

        public override string GetCommandName()
        {
            return "Where my anagrams at ?";
        }
    }
}
