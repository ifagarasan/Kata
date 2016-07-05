namespace SocialNetwork.Command.Processor
{
    public class DisplayUserTimelineProcessor : CommandProcessor
    {
        public DisplayUserTimelineProcessor(ISocialEngine socialEngine, IConsole console):
            base(socialEngine, console)
        {
        }

        public override void Process(ICommand command)
        {
            var displayUserPosts = command as DisplayUserTimeline;

            foreach (var message in SocialEngine.RetrieveUserMessages(displayUserPosts.Username))
                Console.Write(message);
        }
    }
}