using System.Collections.Generic;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post.Format;

namespace SocialNetwork.Model.Post.Printer
{
    public class PostPrinter: IPostPrinter
    {
        private readonly IPostFormatter _postFormatter;
        private readonly IConsole _console;

        public PostPrinter(IPostFormatter postFormatter, IConsole console)
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