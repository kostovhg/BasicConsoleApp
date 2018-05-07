using System;

namespace Test.Commands
{
    class BitCounting : BaseCommand
    {
        private readonly int Number = 4;

        public override void Run()
        {
            UInt64 number = 0;
            Console.WriteLine("Enter positive integer number: ");
            if (UInt64.TryParse(Console.ReadLine(), out number))
            {
                ulong count = 0;
                while (number > 0)
                {
                    count += number & 1;
                    number >>= 1;
                }
                Console.WriteLine("Count of bytes equal to 1 in entered number are {0}", count);
                return;
            }
            Console.WriteLine("You didn't enter a correct nubmer.");
        }

        public override void ProgramInfo()
        {
            throw new NotImplementedException();
        }

        public override int GetProgramNumber()
        {
            return this.Number;
        }

        public override string GetCommandName()
        {
            return "Bit Counting";
        }
    }
}
