using SocialNetwork.Infrastructure;

namespace SocialNetwork.Action.Command
{
    public class DisplayTimeline : Command
    {
        public DisplayTimeline(ISocialEngine socialEngine, IConsole console, string[] arguments) : base(socialEngine, console, arguments)
        {
        }

        public override void Execute()
        {
            foreach (var message in SocialEngine.RetrieveTimeline(Arguments[0]))
                Console.Write(message);
        }
    }
}