using System.Text;

namespace Test.Commands
{
    public interface IWriter
    {
        void WriteLine(string line);

        void WriteLine(StringBuilder sb);

        void WriteLine(string format, object[] args);

        void WriteLine(string format, string arg);

        void WriteHeading(string heading);
    }
}