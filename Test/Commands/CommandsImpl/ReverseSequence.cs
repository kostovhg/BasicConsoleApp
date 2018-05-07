using System;
using System.Linq;

namespace Test.Commands
{
    internal class ReverseSequence : BaseCommand
    {

        private readonly int Number = 9;

        public override void Run()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(" ", (from i in Enumerable.Range(1, n)
                                                select n--)));
        }

        public override void ProgramInfo()
        {
            Console.WriteLine("Get the number n to return the reversed sequence from n to 1.");
        }

        public override int GetProgramNumber()
        {
            return this.Number;
        }

        public override string GetCommandName()
        {
            return "Reversed sequence";
        }
        
    }
}