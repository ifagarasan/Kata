using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.User;

namespace SocialNetwork.Action.Command
{
    public class Post : ICommand
    {
        private readonly ISocialEngine _socialEngine;

        public Post(ISocialEngine socialEngine, User user, string message)
        {
            _socialEngine = socialEngine;
            User = user;
            Message = message;
        }

        public User User { get; }
        public string Message { get; }

        public void Execute()
        {
            _socialEngine.Post(User, Message);
        }
    }
}