using SocialNetwork.Command;
using SocialNetwork.Command.Processor;

namespace SocialNetwork
{
    public class FollowProcessor: CommandProcessor
    {
        public FollowProcessor(ISocialEngine socialEngine, IConsole console) : base(socialEngine, console)
        {
        }

        public override void Process(ICommand command)
        {
            var followCommand = command as Follow;

            SocialEngine.Follow(followCommand.Username, followCommand.FollowUsername);
        }
    }
}