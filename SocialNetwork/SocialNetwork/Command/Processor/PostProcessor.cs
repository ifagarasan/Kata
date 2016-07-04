using System;

namespace SocialNetwork.Command.Processor
{
    public class PostProcessor : CommandProcessor
    {
        public PostProcessor(ISocialEngine socialEngine, IConsole console) : base(socialEngine, console)
        {
        }

        public override void Process(ICommand command)
        {
            PostMessage post = command as PostMessage;

            SocialEngine.Post(post.Username, post.Message);
        }
    }
}