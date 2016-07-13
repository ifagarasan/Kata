using SocialNetwork.Model.Command;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Action.Command
{
    public class DisplayWall: ICommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostPrinter _postPrinter;

        public DisplayWall(IPostRepository postRepository, IUserRepository userRepository, IPostPrinter postPrinter, string username)
        {
            Username = username;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _postPrinter = postPrinter;
        }

        public string Username { get; }

        public void Execute()
        {
            _postPrinter.Print(_postRepository.RetrieveWall(_userRepository.Get(Username)));
        }
    }
}