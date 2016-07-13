using SocialNetwork.Action.Command;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Writer;
using SocialNetwork.Model.User;

namespace SocialNetwork.Model.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostWriter _wallWriter;
        private readonly IPostWriter _timelineWriter;

        public CommandFactory(IPostRepository postRepository, IUserRepository userRepository, IPostWriter wallWriter, IPostWriter timelineWriter)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _wallWriter = wallWriter;
            _timelineWriter = timelineWriter;
        }

        public ICommand Create(CommandInput commandInput)
        {
            switch (commandInput.Type)
            {
                case InputType.Post:
                    return new Action.Command.Post(_postRepository, _userRepository, commandInput.Arguments[0], commandInput.Arguments[1]);
                case InputType.DisplayWall:
                    return new DisplayWall(_postRepository, _userRepository, _wallWriter, commandInput.Arguments[0]);
                case InputType.DisplayTimeline:
                    return new DisplayTimeline(_postRepository, _timelineWriter, commandInput.Arguments[0]);
                case InputType.Follow:
                    return new Follow(_userRepository, commandInput.Arguments[0], commandInput.Arguments[1]);
                default:
                    throw new CommandNotDefinedException($"Command not defined for {commandInput.GetType()}");
            }
        }
    }
}