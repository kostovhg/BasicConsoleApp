using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Commands
{
    public class ExitProgram : IRunnable
    {

        public void Run()
        {
            Console.WriteLine("Exiting the program");
        }

        public void ProgramInfo()
        {
            Console.WriteLine("End the program");
        }

        public int GetProgramNumber()
        {
            return 0;
        }
    }
}
