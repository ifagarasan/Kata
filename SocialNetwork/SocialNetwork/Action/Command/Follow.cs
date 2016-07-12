using SocialNetwork.Model.Command;
using IUserRepository = SocialNetwork.Model.User.IUserRepository;

namespace SocialNetwork.Action.Command
{
    public class Follow: ICommand
    {
        private readonly IUserRepository _repository;

        public Follow(IUserRepository repository, string username, string followUsername)
        {
            _repository = repository;

            Username = username;
            FollowUsername = followUsername;
        }

        public string Username { get; }

        public string FollowUsername { get; }

        public void Execute() => _repository.Get(Username).AddFollower(FollowUsername);
    }
}