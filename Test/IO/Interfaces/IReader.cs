using System;
using System.Collections.Generic;

namespace Test.Commands
{
    public interface IReader
    {
        List<string> ReadInputParameters();

        List<string> ReadInputParameters(string sep);

        ConsoleKeyInfo ReadKeyPusshed();
    }
}