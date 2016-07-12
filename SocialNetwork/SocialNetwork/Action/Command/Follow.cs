using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.User;

namespace SocialNetwork.Action.Command
{
    public class Follow: ICommand
    {
        private readonly ISocialEngine _socialEngine;

        public Follow(ISocialEngine socialEngine, User user, User followUser)
        {
            User = user;
            FollowUser = followUser;
            _socialEngine = socialEngine;
        }

        public User User { get; }
        public User FollowUser { get; }

        public void Execute() => _socialEngine.Follow(User, FollowUser);
    }
}