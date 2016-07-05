using SocialNetwork.Exceptions;

namespace SocialNetwork.Command.Processor
{
    public class CommandProcessorFactory : ICommandProcessorFactory
    {
        private readonly ISocialEngine _socialEngine;
        private readonly IConsole _console;

        public CommandProcessorFactory(ISocialEngine socialEngine, IConsole console)
        {
            _socialEngine = socialEngine;
            _console = console;
        }

        public ICommandProcessor Create(ICommand command)
        {
            var commandProcessor = default(CommandProcessor);

            if (command is PostMessage)
                commandProcessor = new PostProcessor(_socialEngine, _console);
            else if (command is DisplayTimeline)
                commandProcessor = new DisplayTimelineProcessor(_socialEngine, _console);
            else if (command is DisplayWall)
                commandProcessor = new DisplayWallProcessor(_socialEngine, _console);
            else if (command is Follow)
                return new FollowProcessor(_socialEngine, _console);

            if (commandProcessor == null)
                throw new CommandProcessorNotDefinedException($"Command processor not defined for {command.GetType()}");

            return commandProcessor;
        }
    }
}