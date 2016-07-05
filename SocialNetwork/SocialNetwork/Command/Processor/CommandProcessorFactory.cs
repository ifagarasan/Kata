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
            else if (command is DisplayUserTimeline)
                commandProcessor = new DisplayUserTimelineProcessor(_socialEngine, _console);

            return commandProcessor;
        }
    }
}