using System;
using System.Linq;

namespace Test.Commands
{
    class BinaryAddition : IRunnable
    {
        private readonly int Number = 6;

        public void Run()
        {
            Console.WriteLine("Enter two numbers separated by single space: ");
            long tmp;
            try
            {
                long[] input = Console.ReadLine().Split(" ").SelectMany(s => long.TryParse(s, out tmp) ? new[] { tmp } : new long[0]).ToArray();
                Console.WriteLine(SumToNumbersInBinary(input[0], input[1]));
            } catch (Exception e)
            {
                Console.WriteLine("Incorect input!");
            }
        }

        private String SumToNumbersInBinary(long first, long second)
        {
            return Convert.ToString(first + second, 2);
        }

        public void ProgramInfo()
        {
            Console.WriteLine("Adds two numbers together and returns their sum in binary");
        }

        public int GetProgramNumber()
        {
            return this.Number;
        }
    }
}
