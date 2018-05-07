using System;
using System.Linq;

namespace Test.Commands
{
    internal class JadenCassing : BaseCommand
    {
        public override int Number { get { return 8; } }

        public override string Name { get { return "Jaden Casing Strings"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Capitalize each word in sentence.";
            }
        }
        public override void Run()
        {
            writer.WriteLine("\nEnter sentence to be transformed to Jaden-Cased: ");
            String[] input = reader.ReadInputParameters(" ").ToArray();
            writer.WriteLine("\nResult: " + ConvertToJadenCase(input));
        }

        private String ConvertToJadenCase(string[] input)
        {
            return String.Join(" ", input
                .Select(w => char.ToUpper(w[0]) + w.Substring(1))
                .ToArray());
        }
    }
}