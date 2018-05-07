namespace Test
{
    internal interface IRunnable
    {
        int Number { get; }

        string Name { get; }

        string ProgramInfo { get; }

        void Run();

        void PrintHeading();
               
    }
}