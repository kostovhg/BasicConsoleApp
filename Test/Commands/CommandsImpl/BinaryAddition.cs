using System;
using System.Linq;

namespace Test.Commands
{
    class BinaryAddition : BaseCommand
    {
        public override int Number { get { return 6; } }

        public override string Name { get { return "Binary Addition"; } }

        public override string ProgramInfo
        { get { return "Adds two numbers together and returns their sum in binary"; } }


        public override void Run()
        {
            writer.WriteLine("\nEnter two numbers separated by single space: ");
            long tmp;
            try
            {
                long[] input = Console.ReadLine().Split(" ").SelectMany(s => long.TryParse(s, out tmp) ? new[] { tmp } : new long[0]).ToArray();
                writer.WriteLine("\nBinary representation of the sum is : "+ SumToNumbersInBinary(input[0], input[1]));
            } catch (Exception e)
            {
                writer.WriteLine("\nIncorect input!");
            }
        }

        private String SumToNumbersInBinary(long first, long second)
        {
            return Convert.ToString(first + second, 2);
        }
    }
}
