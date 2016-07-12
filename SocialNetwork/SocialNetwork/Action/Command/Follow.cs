using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Social.Engine;

namespace SocialNetwork.Action.Command
{
    public class Follow: ICommand
    {
        private readonly ISocialEngine _socialEngine;

        public Follow(ISocialEngine socialEngine, string username, string usernameToFollow)
        {
            Username = username;
            UsernameToFollow = usernameToFollow;
            _socialEngine = socialEngine;
        }

        public string Username { get; }
        public string UsernameToFollow { get; }

        public void Execute()
        {
            _socialEngine.Follow(Username, UsernameToFollow);
        }
    }
}