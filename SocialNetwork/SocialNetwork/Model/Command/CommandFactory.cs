using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;

namespace SocialNetwork.Model.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostFormatter _postFormatter;
        private readonly IConsole _console;

        public CommandFactory(IPostRepository postPostRepository, IUserRepository userRepository, IPostFormatter postFormatter, IConsole console)
        {
            _postRepository = postPostRepository;
            _userRepository = userRepository;
            _postFormatter = postFormatter;
            _console = console;
        }

        public ICommand Create(CommandInput commandInput)
        {
            switch (commandInput.Type)
            {
                case InputType.Post:
                    return new Action.Command.Post(_postRepository, _userRepository, commandInput.Arguments[0], commandInput.Arguments[1]);
                case InputType.DisplayWall:
                    return new DisplayWall(_postRepository, _userRepository, _postFormatter, _console, commandInput.Arguments[0]);
                case InputType.DisplayTimeline:
                    return new DisplayTimeline(_postRepository, _postFormatter, _console, commandInput.Arguments[0]);
                case InputType.Follow:
                    return new Follow(_userRepository, commandInput.Arguments[0], commandInput.Arguments[1]);
                default:
                    throw new CommandNotDefinedException($"Command not defined for {commandInput.GetType()}");
            }
        }
    }
}