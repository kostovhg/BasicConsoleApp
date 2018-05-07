using System;

namespace Test.Commands
{
    public abstract class BaseCommand : IRunnable
    {
        public virtual int Number { get { return -1; } }

        public virtual string Name { get { return "Basic command"; } }

        public virtual string ProgramInfo { get { return "Info for each app"; } }

        private static IReader _reader;
        private static IWriter _writer;
        public IReader reader {
            get
            {
                if (_reader == null)
                    _reader = new ConsoleReader();
                return _reader;
            }
            set { _reader = value; }
        }
        public IWriter writer
        {
            get
            {
                if (_writer == null)
                    _writer = new ConsoleWriter();
                return _writer;
            }
            set { _writer = value; }
        }

        protected BaseCommand() { }

        public virtual void Run()
        {
            Console.WriteLine("Run some program ...");
        }

        public void PrintHeading()
        {
            writer.WriteHeading(Name);
            writer.WriteLine(ProgramInfo);
        }
    }
}
