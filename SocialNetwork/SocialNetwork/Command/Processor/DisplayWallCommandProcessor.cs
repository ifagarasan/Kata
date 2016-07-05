namespace SocialNetwork.Command.Processor
{
    public class DisplayWallCommandProcessor: CommandProcessor
    {
        public DisplayWallCommandProcessor(ISocialEngine socialEngine, IConsole console) : base(socialEngine, console)
        {
        }

        public override void Process(ICommand command)
        {
            var displayWall = command as DisplayWall;

            foreach (var message in SocialEngine.RetrieveWall(displayWall.Username))
                Console.Write(message);
        }
    }
}