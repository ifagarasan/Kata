using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Social.Engine;

namespace SocialNetwork.Model.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly ISocialEngine _socialEngine;
        private readonly IConsole _console;

        public CommandFactory(ISocialEngine socialEngine, IConsole console)
        {
            _socialEngine = socialEngine;
            _console = console;
        }

        public ICommand Create(CommandInput commandInput)
        {
            switch (commandInput.Type)
            {
                case InputType.Post:
                    return new Action.Command.Post(_socialEngine, commandInput.Arguments[0], commandInput.Arguments[1]);
                case InputType.DisplayWall:
                    return new DisplayWall(_socialEngine, _console, commandInput.Arguments[0]);
                case InputType.DisplayTimeline:
                    return new DisplayTimeline(_socialEngine, _console, commandInput.Arguments[0]);
                case InputType.Follow:
                    return new Follow(_socialEngine, commandInput.Arguments[0], commandInput.Arguments[1]);
                default:
                    throw new CommandNotDefinedException($"Command not defined for {commandInput.GetType()}");
            }
        }
    }
}