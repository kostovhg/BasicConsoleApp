using System;
using System.Linq;
using System.Text;

namespace Test.Commands
{
    public class WordsReverse : BaseCommand
    {

        public override int Number { get { return 2; } }

        public override string Name { get { return "Reverse Words"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Program that utilize a function which accepts a string as parameter, and reverses each word in the string.";
            }
        }

        public override void Run()
        {
            writer.WriteLine("\nEnter the string to be reverced: ");
            writer.WriteLine("\nResult : " + ReverseWords(reader.ReadInput()));
            //Console.WriteLine("Result : {0}", LambdaReverseWords(Console.ReadLine()));
        }

        private string ReverseWords(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in input.Split(" "))
            {
                char[] inversed = new char[word.Length];
                for (int i = inversed.Length - 1, j = 0; i > -1; i--, j++)
                {
                    inversed[i] = word[j];
                }
                sb.Append(new String(inversed)).Append(" ");
            }

            return sb.ToString().Trim();
        }

        private string LambdaReverseWords(string input)
        {
            return string.Join(" ", input.Split(" ").Select(w => new string(w.ToCharArray().Reverse().ToArray())));
        }
    }
}
