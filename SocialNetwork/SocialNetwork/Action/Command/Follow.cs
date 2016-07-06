using SocialNetwork.Infrastructure;

namespace SocialNetwork.Action.Command
{
    public class Follow: Command
    {
        public Follow(ISocialEngine socialEngine, IConsole console, string[] arguments) : base(socialEngine, console, arguments)
        {
        }

        public override void Execute()
        {
            SocialEngine.Follow(Arguments[0], Arguments[1]);
        }
    }
}