using System;
using System.Collections.Generic;

namespace Test.Commands
{
    internal class ConsoleReader : IReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }

        public List<string> ReadInputParameters(String sep)
        {
            List<string> args = new List<string>();
            Array.ForEach(Console.ReadLine().Split(sep), w => args.Add(w));
            return args;
        }

        public List<string> ReadInputParameters()
        {
            return ReadInputParameters(" ");
        }

        public ConsoleKeyInfo ReadKeyPusshed()
        {
            return Console.ReadKey();
        }
    }
}