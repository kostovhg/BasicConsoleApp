using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Test.Commands
{
    class CommandFactory
    {
        private Dictionary<int, IRunnable> _commands = new Dictionary<int, IRunnable>();

        public CommandFactory()
        {
            SearchForCommands();
        }

        public void RegisterCommand<TRunnable>(int key) where TRunnable : IRunnable, new()
        {
            IRunnable command = new TRunnable();

            _commands.Add(key, command);
        }

        public void ExecuteCommand(int key)
        {
            IRunnable command;
            if (!_commands.TryGetValue(key, out command))
            {
                Console.WriteLine("No such command");
                return;
            }

            command.Run();
        }

        public Dictionary<int, IRunnable> GetCommands()
        {
            return this._commands;
        }

        private void SearchForCommands()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                          .Where(x =>
                          x.GetInterfaces().Contains(typeof(IRunnable))
                          && x.GetConstructor(Type.EmptyTypes) != null)
                          .ToList()
                          .ForEach(x =>
                          {
                              IRunnable c = Activator.CreateInstance(x) as IRunnable;
                              _commands.Add(c.Number, c);
                          });
        }

        private static T Create<T>() where T : IRunnable, new()
        {
            return new T();
        }
    }
}
