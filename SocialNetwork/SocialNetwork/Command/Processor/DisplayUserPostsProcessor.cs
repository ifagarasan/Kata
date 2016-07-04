namespace SocialNetwork.Command.Processor
{
    public class DisplayUserPostsProcessor : CommandProcessor
    {
        public DisplayUserPostsProcessor(ISocialEngine socialEngine, IConsole console):
            base(socialEngine, console)
        {
        }

        public override void Process(ICommand command)
        {
            var displayUserPosts = command as DisplayUserPosts;

            foreach (var message in SocialEngine.RetrieveUserMessages(displayUserPosts.Username))
                Console.Write(message);
        }
    }
}