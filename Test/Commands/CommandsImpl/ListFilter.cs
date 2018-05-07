using System;
using System.Collections.Generic;

namespace Test.Commands
{
    class ListFilter : BaseCommand
    {
        private readonly int Number = 5;

        public override void Run()
        {
            List<object> list = new List<object>();
            String[] input = Console.ReadLine().Split(", ");
            // Artificially creating string and integer objects from string input
            foreach (object o in input)
            {
                if (o.ToString().StartsWith("\""))
                {
                    string st = o.ToString();
                    list.Add(st.Replace("\"", ""));
                }
                else
                {
                    list.Add(Int32.Parse(o.ToString()));
                }
            }
            Console.WriteLine("{{{0}}}", String.Join(", ", GetIntegersFromList(list)).PadLeft(32, '0'));
        }

        private List<int> GetIntegersFromList(List<object> initialList)
        {
            List<int> integerList = new List<int>();
            int tmp;
            foreach (object o in initialList)
            {
                //if(o is int))
                if(Int32.TryParse(o.ToString(), out tmp))
                {
                    integerList.Add(tmp);
                }
            }

            return integerList;
        }

        public override void ProgramInfo()
        {
            Console.WriteLine("Takes a list of non - negative integers and strings and returns a new list with the strings filtered out");
        }

        public override int GetProgramNumber()
        {
            return this.Number;
        }

        public override string GetCommandName()
        {
            return "List Filtering";
        }
    }
}
