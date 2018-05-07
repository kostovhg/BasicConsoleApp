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
            Console.CursorVisible = false;
            do
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.Write("\nEnter number between 0 and {0}: ", commands.Count - 1);
                if (Int32.TryParse(Console.ReadLine(), out choise) && choise >= 0 && choise < commands.Count)
                {
                    Console.Clear();
                    IRunnable command = commands[choise];
                    command.PrintHeading();
                    command.Run();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You did not enter a correct number.");
                }
                choise = AskForExit();
            } while (choise != 0);
        }

        private static int AskForExit()
        {
            if (choise != 0)
            {
                Console.WriteLine("\nDo you like to go back to commands menu [y/n] (default y):");
                string answer = Console.ReadLine();
                if (answer.Equals("n"))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        private static string InitMenuList()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Apps menu").Append(Environment.NewLine);
            sb.Append("----------").Append(Environment.NewLine);

            menuItems.ForEach(i => sb.Append(i).Append(Environment.NewLine));
            return sb.ToString();
        }

        // Only for test purposes
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
            List<string> strMenuItems = commands
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => String.Format("{0}. {1}", kvp.Key, kvp.Value.Name))
                .ToList();
            string tmp = strMenuItems[0];

            // Get 0. Exit to the end
            strMenuItems.RemoveAt(0);
            strMenuItems.Add(tmp);

            return strMenuItems;
        }

    }
}
