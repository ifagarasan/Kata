using System.Linq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;

namespace SocialNetwork.Action.Command
{
    public class DisplayWall: ICommand
    {
        private readonly IRepository _repository;
        private readonly IPostFormatter _postFormatter;
        private readonly IConsole _console;

        public DisplayWall(IRepository repository, IPostFormatter postFormatter, IConsole console, User user)
        {
            User = user;
            _repository = repository;
            _postFormatter = postFormatter;
            _console = console;
        }

        public User User { get; }

        public void Execute()
        {
            foreach (var message in _repository.RetrieveWall(User).Select(p => _postFormatter.FormatWallPost(p)))
                _console.Write(message);
        }
    }
}