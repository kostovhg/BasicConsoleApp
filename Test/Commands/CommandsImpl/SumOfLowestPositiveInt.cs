using System;
using System.Linq;

namespace Test.Commands
{
    internal class SumOfLowestPositiveInt : BaseCommand
    {
        public override int Number { get { return 7; } }

        public override string Name { get { return "Sum of two lowest positive integers"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Returns the sum of the two lowest positive numbers given an array of minimum 4 integers.";
            }
        }

        public override void Run()
        {
            writer.WriteLine("\nWrite array of integers separated by comma and single space: ");
            int tmp;
            int[] input = reader.ReadInputParameters(", ")
                .SelectMany(s => int.TryParse(s, out tmp) ? new[] { tmp } : new int[0])
                .ToArray();
            writer.WriteLine("\nThe sum of two minimum positive elements of the array is: " + SumOfTwoLowestPositiveInt(input));
        }

        private int SumOfTwoLowestPositiveInt(int[] input)
        {
            return input.Where(i => i > 0).OrderBy(i => i).Take(2).Sum();
        }
    }
}