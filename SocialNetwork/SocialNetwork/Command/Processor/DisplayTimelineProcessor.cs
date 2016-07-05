namespace SocialNetwork.Command.Processor
{
    public class DisplayTimelineProcessor : CommandProcessor
    {
        public DisplayTimelineProcessor(ISocialEngine socialEngine, IConsole console):
            base(socialEngine, console)
        {
        }

        public override void Process(ICommand command)
        {
            var displayTimeline = command as DisplayTimeline;

            foreach (var message in SocialEngine.RetrieveTimeline(displayTimeline.Username))
                Console.Write(message);
        }
    }
}