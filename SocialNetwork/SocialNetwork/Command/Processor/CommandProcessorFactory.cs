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
            return new PostProcessor(_socialEngine, _console);
        }
    }
}