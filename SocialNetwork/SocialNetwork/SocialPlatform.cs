namespace SocialNetwork
{
    public class SocialPlatform: ISocialPlatform
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ICommandProcessor _commandProcessor;

        public SocialPlatform(ICommandDispatcher commandDispatcher, ICommandProcessor commandProcessor)
        {
            _commandDispatcher = commandDispatcher;
            _commandProcessor = commandProcessor;
        }

        public void Run()
        {
            var command = _commandDispatcher.Retrieve();

            _commandProcessor.Process(command);
        }
    }
}