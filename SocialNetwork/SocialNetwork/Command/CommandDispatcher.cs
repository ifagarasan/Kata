namespace SocialNetwork.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandTranslator _commandTranslator;
        private readonly IConsole _console;

        public CommandDispatcher(ICommandTranslator commandTranslator, IConsole console)
        {
            _console = console;
            _commandTranslator = commandTranslator;
        }

        public ICommand Retrieve()
        {
            return _commandTranslator.Translate(_console.Read());
        }
    }
}