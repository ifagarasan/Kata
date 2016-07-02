namespace SocialNetwork
{
    public class CommandProcessor : ICommandProcessor
    {
        private IConsole _console;
        private ISocialEngine _socialEngine;

        public CommandProcessor(ISocialEngine socialEngine, IConsole console)
        {
            _socialEngine = socialEngine;
            _console = console;
        }

        public void Process(ICommand command)
        {
            var postCommand = command as PostCommand;

            _socialEngine.Post(postCommand.Username, postCommand.Content);
        }
    }
}