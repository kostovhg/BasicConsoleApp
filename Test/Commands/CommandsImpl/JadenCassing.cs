using System;
using System.Linq;

namespace Test.Commands
{
    internal class JadenCassing : BaseCommand
    {
        private readonly int Number = 8;
       public override void Run()
        {
            Console.WriteLine("Enter sentence to be transformed to Jaden-Cased: ");
            String[] input = Console.ReadLine().Split();
            Console.WriteLine(ConvertToJadenCase(input));
        }

        private String ConvertToJadenCase(string[] input)
        {
            return String.Join(" ", input
                .Select(w => char.ToUpper(w[0]) + w.Substring(1))
                .ToArray());
        }

        public override void ProgramInfo()
        {
            Console.WriteLine("Capitalize each word in sentence");
        }

        public override int GetProgramNumber()
        {
            return this.Number;
        }

        public override string GetCommandName()
        {
            return "Jaden Casing Strings";
        }
    }
}