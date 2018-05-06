using System;
using System.Linq;

namespace Test.Commands
{
    internal class JadenCassing : IRunnable
    {
        private readonly int Number = 8;
       public void Run()
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

        public void ProgramInfo()
        {
            Console.WriteLine("Capitalize each word in sentence");
        }

        public int GetProgramNumber()
        {
            return this.Number;
        }
    }
}