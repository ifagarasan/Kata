using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Social.Engine;

namespace SocialNetwork.Action.Command
{
    public class Post : ICommand
    {
        private readonly ISocialEngine _socialEngine;

        public Post(ISocialEngine socialEngine, string username, string message)
        {
            _socialEngine = socialEngine;
            Username = username;
            Message = message;
        }

        public string Username { get; }
        public string Message { get; }

        public void Execute()
        {
            _socialEngine.Post(Username, Message);
        }
    }
}