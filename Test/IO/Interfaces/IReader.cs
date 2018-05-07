using System;
using System.Collections.Generic;

namespace Test.Commands
{
    public interface IReader
    {
        string ReadInput();

        List<string> ReadInputParameters();

        List<string> ReadInputParameters(string sep);

        ConsoleKeyInfo ReadKeyPusshed();
    }
}