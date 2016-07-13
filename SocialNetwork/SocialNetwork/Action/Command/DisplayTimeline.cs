using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Action.Command
{
    public class DisplayTimeline: ICommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostPrinter _postPrinter;

        public DisplayTimeline(IPostRepository postRepository, IPostPrinter postPrinter, string username)
        {
            Username = username;
            _postRepository = postRepository;
            _postPrinter = postPrinter;
        }

        public string Username { get; }

        public void Execute()
        {
            _postPrinter.Print(_postRepository.RetrieveTimeline(Username));
        }
    }
}