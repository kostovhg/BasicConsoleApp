using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Commands
{
    public class VowelCount : BaseCommand
    {
        public override int Number { get { return 1; } }

        public override string Name { get { return "Vowel Count"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Return the number (count) of vowels in the given string.\n" +
                "We will consider a, e, i, o, and u as vowels for this task.\n" +
                "The input string will only consist of lower case letters and / or spaces.";
            }
        }

        private static char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        public override void Run()
        {
            writer.WriteLine("\nEnter the string which vowels will be counted: ");
            string theString = Console.ReadLine();
            int count = theString.Count(c => vowels.Contains(c));
            writer.WriteLine("\nThe total number of vowels is: " + count);
        }
    }
}
