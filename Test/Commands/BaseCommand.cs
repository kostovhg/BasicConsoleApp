using System;

namespace Test.Commands
{
    public abstract class BaseCommand : IRunnable
    {
        protected static int CommandNumber = -1;
        protected string CommandName = "Basic Command";
        private static IReader _reader;
        private static IWriter _writer;
        protected IReader reader {
            get
            {
                if (_reader == null)
                    _reader = new ConsoleReader();
                return _reader;
            }
            set { _reader = value; }
        }
        protected IWriter writer
        {
            get
            {
                if (_writer == null)
                    _writer = new ConsoleWriter();
                return _writer;
            }
            set { _writer = value; }
        }

        protected BaseCommand()
        {
        }

        public virtual int GetProgramNumber()
        {
            return CommandNumber;
        }

        public virtual void ProgramInfo()
        {
            Console.WriteLine("Info for each app");
        }

        public virtual void Run()
        {
            Console.WriteLine("Run some program ...");
        }

        public virtual string GetCommandName()
        {
            return this.CommandName;
        }
    }
}
