using System.Linq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Action.Command
{
    public class DisplayWall: ICommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostFormatter _postFormatter;
        private readonly IConsole _console;

        public DisplayWall(IPostRepository postRepository, IUserRepository userRepository, IPostFormatter postFormatter, IConsole console, string username)
        {
            Username = username;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _postFormatter = postFormatter;
            _console = console;
        }

        public string Username { get; }

        public void Execute()
        {
            var user = _userRepository.Get(Username);

            foreach (var message in _postRepository.RetrieveWall(user).Select(p => _postFormatter.FormatWallPost(p)))
                _console.Write(message);
        }
    }
}