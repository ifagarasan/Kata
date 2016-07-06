using SocialNetwork.Action.Command;
using SocialNetwork.Action.Command.Input;

namespace SocialNetwork.Action
{
    public class SocialPlatform: ISocialPlatform
    {
        private readonly ITaskDispatcher _taskDispatcher;
        private readonly ICommandFactory _commandFactory;

        public SocialPlatform(ITaskDispatcher taskDispatcher, ICommandFactory commandFactory)
        {
            _taskDispatcher = taskDispatcher;
            _commandFactory = commandFactory;
        }

        public void Run()
        {
            while (true)
            {
                var command = _taskDispatcher.Retrieve();
                if (command.Type == CommandType.Exit)
                    break;

                var commandProcessor = _commandFactory.Create(command);

                commandProcessor.Execute();
            }
        }
    }
}