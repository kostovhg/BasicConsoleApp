using System;
using System.Collections.Generic;
using System.Text;
using Test.Commands;

namespace Test
{
    class Program
    {
        private static int choise = 0;
        private static IRunnable[] runnables = initializeCommands();    
        private static readonly CommandFactory commandFactory = new CommandFactory();
        private static Dictionary<int, IRunnable> commands = commandFactory.GetCommands();

        private static IRunnable[] initializeCommands() => new IRunnable[]
                {
                   new ExitProgram(),
                   new VowelCount(),
                   new WordsReverse(),
                   new AnagramsCount(),
                   new BitCounting(),
                   new ListFilter(),
                   new BinaryAddition(),
                   new SumOfLowestPositiveInt(),
                   new JadenCassing(),
                   new ReverseSequence(),
                   new GetProducts(),
                   new GetSalesTotaling(),
                   new GetMonthOverMonthGrowRate(),
                   new GetWorkDaysBetweenDates()
                };

        private static string menu = InitMenuList();

        static void Main(string[] args)
        {

            Console.WriteLine("Select task: ");
            
            do
            {
                Console.Write(menu);
                if (Int32.TryParse(Console.ReadLine(), out choise) && choise >= 0 && choise < runnables.Length)
                {
                    runnables[choise].Run();
                }
                else
                {
                    Console.WriteLine("You did not enter a correct number.");
                    choise = AskForExit();
                    Console.ReadLine();
                }

            } while (choise != 0);
        }

        private static int AskForExit()
        {
            return 0;
        }

        private static string InitMenuList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1. Vowel Count ").Append(Environment.NewLine);
            sb.Append("2. Reverse words").Append(Environment.NewLine);
            sb.Append("3. Where my anagrams at ?").Append(Environment.NewLine);
            sb.Append("4. Bit Counting").Append(Environment.NewLine);
            sb.Append("5. List Filtering").Append(Environment.NewLine);
            sb.Append("6. Binary Addition").Append(Environment.NewLine);
            sb.Append("7. Sum of two lowest positive integers").Append(Environment.NewLine);
            sb.Append("8. Jaden Casing Strings").Append(Environment.NewLine);
            sb.Append("9. Reversed sequence").Append(Environment.NewLine);
            sb.Append("10. SQL Basics: Simple JOIN").Append(Environment.NewLine);
            sb.Append("11. SQL Bug Fixing: Fix the QUERY - Totaling").Append(Environment.NewLine);
            sb.Append("12. Calculating Month-Over-Month Percentage Growth Rate").Append(Environment.NewLine);
            sb.Append("13. Count Weekdays").Append(Environment.NewLine);
            sb.Append("0. Exit").Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
