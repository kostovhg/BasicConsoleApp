
namespace Test.Commands
{
    public class ExitProgram : BaseCommand
    {

        public override int Number { get { return 0; } }

        public override string Name { get { return "Exit"; } }

        public override string ProgramInfo
        { get { return "Leave the app"; } }


        public override void Run()
        {
            // nothing
        }
    }
}
