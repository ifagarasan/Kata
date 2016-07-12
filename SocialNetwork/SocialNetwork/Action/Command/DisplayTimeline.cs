using System.Linq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Action.Command
{
    public class DisplayTimeline: ICommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostFormatter _postFormatter;
        private readonly IConsole _console;

        public DisplayTimeline(IPostRepository postRepository, IPostFormatter postFormatter, IConsole console, string username)
        {
            Username = username;
            _postRepository = postRepository;
            _postFormatter = postFormatter;
            _console = console;
        }

        public string Username { get; }

        public void Execute()
        {
            foreach (var message in _postRepository.RetrieveTimeline(Username).Select(p => _postFormatter.FormatTimelinePost(p)))
                _console.Write(message);
        }
    }
}