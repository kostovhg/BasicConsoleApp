using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Commands
{
    public class ExitProgram : BaseCommand
    {

        public override void Run()
        {
            Console.WriteLine("Exiting the program");
        }

        public override void ProgramInfo()
        {
            Console.WriteLine("End the program");
        }

        public override int GetProgramNumber()
        {
            return 0;
        }
    }
}
