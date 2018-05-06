using System;
using System.Linq;

namespace Test.Commands
{
    internal class ReverseSequence : IRunnable
    {

        private readonly int Number = 9;

        public void Run()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(" ", (from i in Enumerable.Range(1, n)
                                                select n--)));
        }

        public void ProgramInfo()
        {
            Console.WriteLine("Get the number n to return the reversed sequence from n to 1.");
        }

        public int GetProgramNumber()
        {
            return this.Number;
        }
    }
}