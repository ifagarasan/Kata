using SocialNetwork.Command.Processor;

namespace SocialNetwork
{
    public class SocialPlatform: ISocialPlatform
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ICommandProcessorFactory _commandProcessorFactory;

        public SocialPlatform(ICommandDispatcher commandDispatcher, ICommandProcessorFactory commandProcessorFactory)
        {
            _commandDispatcher = commandDispatcher;
            _commandProcessorFactory = commandProcessorFactory;
        }

        public void Run()
        {
            var command = _commandDispatcher.Retrieve();
            var commandProcessor = _commandProcessorFactory.Create(command);

            commandProcessor.Process(command);

            //_commandProcessorFactory.Process(command);
        }
    }
}