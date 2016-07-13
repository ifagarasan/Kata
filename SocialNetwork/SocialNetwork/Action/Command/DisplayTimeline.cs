using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Writer;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Action.Command
{
    public class DisplayTimeline: ICommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostWriter _postWriter;

        public DisplayTimeline(IPostRepository postRepository, IPostWriter postWriter, string username)
        {
            Username = username;
            _postRepository = postRepository;
            _postWriter = postWriter;
        }

        public string Username { get; }

        public void Execute()
        {
            _postWriter.Print(_postRepository.RetrieveTimeline(Username));
        }
    }
}