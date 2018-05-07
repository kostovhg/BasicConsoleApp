using System;
using System.Text;

namespace Test.Commands
{
    public class ConsoleWriter : IWriter
    {
        char ch = '=';
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void WriteLine(StringBuilder sb)
        {
            WriteLine(sb.ToString());
        }

        public void WriteLine(string format, object[] args)
        {
            Console.WriteLine(String.Format(format, args));
        }

        public void WriteLine(string format, string arg)
        {
            Console.WriteLine(String.Format(format, arg));
        }

        public void WriteHeading(string heading)
        {
            int len = heading.Length;
            string border ="+" + new string(ch, len + 4) + "+" + Environment.NewLine;
            StringBuilder sb = new StringBuilder();
            sb.Append(border);
            sb.Append("+  ").Append(heading).Append("  +").Append(Environment.NewLine);
            sb.Append(border);
            WriteLine(sb);
        }
    }
}