using SocialNetwork.Model.Command;
using SocialNetwork.Model.User;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Action.Command
{
    public class Post : ICommand
    {
        private readonly IPostRepository _repository;
        private readonly IUserRepository _userRepository;

        public Post(IPostRepository repository, IUserRepository userRepository, string username, string message)
        {
            _repository = repository;
            _userRepository = userRepository;

            Username = username;
            Message = message;
        }

        public string Username { get; set; }

        public string Message { get; }

        public void Execute()
        {
            var user = _userRepository.Get(Username) ?? _userRepository.Insert(Username);

            _repository.Insert(user.Username, Message);
        }
    }
}