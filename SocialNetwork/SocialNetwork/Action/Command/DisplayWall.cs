using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Writer;
using SocialNetwork.Model.User;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Action.Command
{
    public class DisplayWall: ICommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostWriter _postWriter;

        public DisplayWall(IPostRepository postRepository, IUserRepository userRepository, IPostWriter postWriter, string username)
        {
            Username = username;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _postWriter = postWriter;
        }

        public string Username { get; }

        public void Execute()
        {
            _postWriter.Print(_postRepository.RetrieveWall(_userRepository.Get(Username)));
        }
    }
}