using System;
using System.Linq;

namespace Test.Commands
{
    internal class SumOfLowestPositiveInt : BaseCommand
    {

        private readonly int Number = 7;

        public override void Run()
        {
            Console.WriteLine("Write array of integers separated by comma and single space: ");
            int tmp;
            int[] input = Console.ReadLine().Split(", ")
                .SelectMany(s => int.TryParse(s, out tmp) ? new[] { tmp } : new int[0])
                .ToArray();
            Console.WriteLine("The sum of two minimum positive elements of the array is: {0}",
                SumOfTwoLowestPositiveInt(input));
        }

        private int SumOfTwoLowestPositiveInt(int[] input)
        {
            return input.Where(i => i > 0).OrderBy(i => i).Take(2).Sum();
        }

        public override void ProgramInfo()
        {
            System.Console.WriteLine("Returns the sum of the two lowest positive numbers given an array of minimum 4 integers");
        }

        public override int GetProgramNumber()
        {
            return this.Number;
        }

        public override string GetCommandName()
        {
            return "Sum of two lowest positive integers";
        }
    }
}