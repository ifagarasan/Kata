using SocialNetwork.Action.Command;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;

namespace SocialNetwork.Model.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostPrinter _wallPrinter;
        private readonly IPostPrinter _timelinePrinter;

        public CommandFactory(IPostRepository postRepository, IUserRepository userRepository, IPostPrinter wallPrinter, IPostPrinter timelinePrinter)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _wallPrinter = wallPrinter;
            _timelinePrinter = timelinePrinter;
        }

        public ICommand Create(CommandInput commandInput)
        {
            switch (commandInput.Type)
            {
                case InputType.Post:
                    return new Action.Command.Post(_postRepository, _userRepository, commandInput.Arguments[0], commandInput.Arguments[1]);
                case InputType.DisplayWall:
                    return new DisplayWall(_postRepository, _userRepository, _wallPrinter, commandInput.Arguments[0]);
                case InputType.DisplayTimeline:
                    return new DisplayTimeline(_postRepository, _timelinePrinter, commandInput.Arguments[0]);
                case InputType.Follow:
                    return new Follow(_userRepository, commandInput.Arguments[0], commandInput.Arguments[1]);
                default:
                    throw new CommandNotDefinedException($"Command not defined for {commandInput.GetType()}");
            }
        }
    }
}