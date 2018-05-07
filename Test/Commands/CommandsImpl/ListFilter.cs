using System;
using System.Collections.Generic;

namespace Test.Commands
{
    class ListFilter : BaseCommand
    {
        public override int Number { get { return 5; } }

        public override string Name { get { return "List Filtering"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Takes a list of non - negative integers and strings and returns a new list with the strings filtered out." +Environment.NewLine +
                    "The program is using Test.Commands.CommandsImpl.ListFilter.GetIntegersFromList(List<object> list)" + Environment.NewLine +
                    "method that returns List<int>.";
            }
        }

        public override void Run()
        {
            List<object> list = new List<object>();
            writer.WriteLine("\nEnter elements separated with \", \" (single comma and space) where string objects should be in double quotes: ");
            String[] input = reader.ReadInputParameters(", ").ToArray();
            // Artificially creating string and integer objects from string input to simulate different element types
            foreach (object o in input)
            {
                int res;
                if (!int.TryParse(o.ToString(), out res))
                {
                    string st = o.ToString();
                    if (o.ToString().StartsWith("\""))
                    {
                        
                        st = st.Replace("\"", "");
                    }
                    list.Add(st);
                }
                else
                {
                    list.Add(res);
                }
            }
            Console.WriteLine("\nResult is: {{{0}}}", String.Join(", ", GetIntegersFromList(list)));
        }

        private List<int> GetIntegersFromList(List<object> initialList)
        {
            List<int> integerList = new List<int>();
            //int tmp;
            foreach (object o in initialList)
            {
                if (o is int)
                {
                    integerList.Add((int)o);
                }
            }

            return integerList;
        }
    }
}
