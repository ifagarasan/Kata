using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Social.Engine;

namespace SocialNetwork.Action.Command
{
    public class DisplayWall: Model.Command.Command
    {
        public DisplayWall(ISocialEngine socialEngine, IConsole console, string[] arguments) : base(socialEngine, console, arguments)
        {
        }

        public override void Execute()
        {
            foreach (var message in SocialEngine.RetrieveWall(Arguments[0]))
                Console.Write(message);
        }
    }
}