using System.Runtime.InteropServices;
using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;

namespace SocialNetwork.Model.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IRepository _repository;
        private readonly IPostFormatter _postFormatter;
        private readonly IConsole _console;

        public CommandFactory(IRepository repository, IPostFormatter postFormatter, IConsole console)
        {
            _repository = repository;
            _postFormatter = postFormatter;
            _console = console;
        }

        public ICommand Create(CommandInput commandInput)
        {
            switch (commandInput.Type)
            {
                case InputType.Post:
                    return new Action.Command.Post(_repository, new User.User(commandInput.Arguments[0]), commandInput.Arguments[1]);
                case InputType.DisplayWall:
                    return new DisplayWall(_repository, _postFormatter, _console, new User.User(commandInput.Arguments[0]));
                case InputType.DisplayTimeline:
                    return new DisplayTimeline(_repository, _postFormatter, _console, new User.User(commandInput.Arguments[0]));
                case InputType.Follow:
                    return new Follow(_repository, new User.User(commandInput.Arguments[0]), new User.User(commandInput.Arguments[1]));
                default:
                    throw new CommandNotDefinedException($"Command not defined for {commandInput.GetType()}");
            }
        }
    }
}