using System;
using System.Linq;
using System.Text;

namespace Test.Commands
{
    public class WordsReverse : IRunnable
    {
        private readonly int Number = 2;

        public void Run()
        {
            Console.WriteLine("Enter the string to be reverced: ");
            Console.WriteLine("Result : {0}", ReverseWords(Console.ReadLine()));
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

        public void ProgramInfo()
        {
            Console.WriteLine("Program that utilize a function which accepts a string as parameter, and reverses each word in the string");
        }

        public int GetProgramNumber()
        {
            return Number;
        }
    }
}
