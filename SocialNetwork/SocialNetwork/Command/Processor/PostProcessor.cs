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
            Post post = command as Post;
        }
    }
}