using System;
using System.Linq;

namespace Test.Commands
{
    internal class ReverseSequence : BaseCommand
    {
        public override int Number { get { return 9; } }

        public override string Name { get { return "Reversed sequence"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Get the number n to return the reversed sequence from n to 1.";
            }
        }

        public override void Run()
        {
            writer.WriteLine("\nEnter n: ");
            int n = int.Parse(reader.ReadInput());
            writer.WriteLine("\nResult: " + String.Join(" ", (from i in Enumerable.Range(1, n)
                                                              select n--)));
        }
    }
}