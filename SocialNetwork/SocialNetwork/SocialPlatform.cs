using SocialNetwork.Command;
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
            while (true)
            {
                //TODO: command processor for exit, returns boolean to continue
                var command = _commandDispatcher.Retrieve();
                if (command is Exit)
                    break;

                var commandProcessor = _commandProcessorFactory.Create(command);

                commandProcessor.Process(command);
            }
        }
    }
}