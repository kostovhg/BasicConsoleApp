using System;

namespace Test.Commands
{
    class BitCounting : BaseCommand
    {
        public override int Number { get { return 4; } }

        public override string Name { get { return "Bit Counting"; } }

        public override string ProgramInfo
        { get { return "Return the number of bits that are equal to one in the binary representation of provided unsigned integer."; } }


        public override void Run()
        {
            UInt64 number = 0;
            writer.WriteLine("\nEnter positive integer number: ");
            if (UInt64.TryParse(reader.ReadInput(), out number))
            {
                ulong count = 0;
                while (number > 0)
                {
                    count += number & 1;
                    number >>= 1;
                }
                writer.WriteLine("\nCount of bytes equal to 1 in entered number are {0}", count.ToString());
                return;
            }
            writer.WriteLine("You didn't enter a correct nubmer.");
        }
    }
}
