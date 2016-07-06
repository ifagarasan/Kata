using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Social.Engine;

namespace SocialNetwork.Action.Command
{
    public class Follow: Model.Command.Command
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