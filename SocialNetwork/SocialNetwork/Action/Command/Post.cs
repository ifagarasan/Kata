using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;

namespace SocialNetwork.Action.Command
{
    public class Post : ICommand
    {
        private readonly IRepository _repository;

        public Post(IRepository repository, User user, string message)
        {
            _repository = repository;
            User = user;
            Message = message;
        }

        public User User { get; }
        public string Message { get; }

        public void Execute() => _repository.Insert(User, Message);
    }
}