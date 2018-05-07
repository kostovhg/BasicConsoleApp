using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Commands;

namespace Test
{
    class Program
    {
        private static int choise = 0;
        private static Dictionary<int, IRunnable> commands = new CommandFactory().GetCommands();
        private static List<String> menuItems = InitMenuItems();
        private static string menu = InitMenuList();

        static void Main(string[] args)
        {  
            Console.WriteLine("Select task: ");

            Console.CursorVisible = false;
            do
            {
                
                if (Int32.TryParse(Console.ReadLine(), out choise) && choise >= 0 && choise < commands.Count)
                {
                    //runnables[choise].Run();
                    commands[choise].Run();
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

        private static string drawMenu(List<string> items)
        {
            Console.CursorVisible = false;
            while (true)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    if (i == choise)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();

                if (ckey.Key == ConsoleKey.DownArrow && choise < menuItems.Count - 1)
                {
                    choise++;
                }
                else if (ckey.Key == ConsoleKey.UpArrow && choise > 0)
                {
                    choise--;
                }
                Console.Clear();
            }
        }

        private static List<string> InitMenuItems()
        {
            List<string> strMenuItems = commands.OrderBy(kvp => kvp.Key).Select(kvp => String.Format("{0}. {1}", kvp.Key, kvp.Value.GetCommandName())).ToList();
            string tmp = strMenuItems[0];
            strMenuItems.RemoveAt(0);
            strMenuItems.Add(tmp);
            return strMenuItems;
        }

    }
}
