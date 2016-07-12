using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Social.Engine;

namespace SocialNetwork.Action.Command
{
    public class DisplayWall: ICommand
    {
        private readonly ISocialEngine _socialEngine;
        private readonly IConsole _console;

        public DisplayWall(ISocialEngine socialEngine, IConsole console, string username)
        {
            _socialEngine = socialEngine;
            _console = console;
            Username = username;
        }

        public string Username { get; }

        public void Execute()
        {
            foreach (var message in _socialEngine.RetrieveWall(Username))
                _console.Write(message);
        }
    }
}