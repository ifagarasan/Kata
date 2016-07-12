using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.User;

namespace SocialNetwork.Action.Command
{
    public class DisplayTimeline: ICommand
    {
        private readonly ISocialEngine _socialEngine;
        private readonly IConsole _console;

        public DisplayTimeline(ISocialEngine socialEngine, IConsole console, User user)
        {
            User = user;
            _socialEngine = socialEngine;
            _console = console;
        }

        public User User { get; }

        public void Execute()
        {
            foreach (var message in _socialEngine.RetrieveTimeline(User))
                _console.Write(message);
        }
    }
}