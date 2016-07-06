using SocialNetwork.Infrastructure;

namespace SocialNetwork.Action.Command
{
    public class Post : Command
    {
        public Post(ISocialEngine socialEngine, IConsole console, string[] arguments) : base(socialEngine, console, arguments)
        {
        }

        public override void Execute()
        {
            SocialEngine.Post(Arguments[0], Arguments[1]);
        }
    }
}