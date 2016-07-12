using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;

namespace SocialNetwork.Action.Command
{
    public class Follow: ICommand
    {
        private readonly IRepository _repository;

        public Follow(IRepository repository, User user, User followUser)
        {
            _repository = repository;
            User = user;
            FollowUser = followUser;
        }

        public User User { get; }
        public User FollowUser { get; }

        public void Execute() => _repository.Follow(User, FollowUser);
    }
}