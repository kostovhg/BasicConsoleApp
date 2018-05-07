using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Commands
{
    public class VowelCount : BaseCommand
    {
        private readonly int number = 1;
        private static char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        public override void Run()
        {
            Console.WriteLine("Enter the string which vowels will be counted: ");
            string theString = Console.ReadLine();
            int count = theString.Count(c => vowels.Contains(c));
            Console.WriteLine("Your total number of vowels is: {0}", count);
        }

        public override void ProgramInfo()
        {
            Console.WriteLine("Return the number (count) of vowels in the given string.\n" +
                "We will consider a, e, i, o, and u as vowels for this task.\n" +
                "The input string will only consist of lower case letters and / or spaces.");
        }

        public override int GetProgramNumber()
        {
            return number;
        }

        public override string GetCommandName()
        {
            return "Vowel Count";
        }
    }
}
