namespace SocialNetwork.Command.Processor
{
    public class DisplayWallCommandProcessor: CommandProcessor
    {
        public DisplayWallCommandProcessor(ISocialEngine socialEngine, IConsole console) : base(socialEngine, console)
        {
        }

        public override void Process(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}