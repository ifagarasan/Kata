using System.Collections.Generic;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post.Format;

namespace SocialNetwork.Model.Post.Writer
{
    public class PostWriter: IPostWriter
    {
        private readonly IPostFormatter _postFormatter;
        private readonly IConsole _console;

        public PostWriter(IPostFormatter postFormatter, IConsole console)
        {
            _postFormatter = postFormatter;
            _console = console;
        }

        public void Print(IList<Post> posts)
        {
            foreach (var post in posts)
                _console.Write(_postFormatter.Format(post));
        }
    }
}