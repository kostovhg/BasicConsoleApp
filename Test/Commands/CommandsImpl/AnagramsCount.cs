using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Commands
{
    class AnagramsCount : BaseCommand
    {
        public override int Number { get { return 3; } }

        public override string Name { get { return "Where my anagrams at ?"; } }

        public override string ProgramInfo
        {
            get
            {
                StringBuilder sb = new StringBuilder(
            "Two words are anagrams of each other if they both contain the same letters." + Environment.NewLine +
            "For example:" + Environment.NewLine +
            "'abba' & 'baab' == true 'abba' & 'bbaa' == true 'abba' & 'abbba' == false" + Environment.NewLine);
                return sb.ToString();
            }
        }


        public override void Run()
        {
            writer.WriteLine("Enter the template: ");
            string template = reader.ReadInputParameters()[0];
            writer.WriteLine("Enter the list of words to be checked separated with single space: ");
            List<string> words = reader.ReadInputParameters();
            writer.WriteLine("\nResult : {0}", string.Join(", ", Anagrams(template, words)));

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
                    if (index > -1)
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

    
    }
}
