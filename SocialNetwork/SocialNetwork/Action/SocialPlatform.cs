using SocialNetwork.Action.Command;
using SocialNetwork.Action.Command.Input;

namespace SocialNetwork.Action
{
    public class SocialPlatform: ISocialPlatform
    {
        private readonly IInputRetriever _commandInputRetriever;
        private readonly ICommandFactory _commandFactory;

        public SocialPlatform(IInputRetriever commandInputRetriever, ICommandFactory commandFactory)
        {
            _commandInputRetriever = commandInputRetriever;
            _commandFactory = commandFactory;
        }

        public void Run()
        {
            while (true)
            {
                var command = _commandInputRetriever.Retrieve();
                if (command.Type == CommandType.Exit)
                    break;

                var commandProcessor = _commandFactory.Create(command);

                commandProcessor.Execute();
            }
        }
    }
}