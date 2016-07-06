using SocialNetwork.Infrastructure;

namespace SocialNetwork.Action.Command.Input
{
    public class TaskDispatcher : ITaskDispatcher
    {
        private readonly IInputBuilder _inputBuilder;
        private readonly IConsole _console;

        public TaskDispatcher(IInputBuilder inputBuilder, IConsole console)
        {
            _console = console;
            _inputBuilder = inputBuilder;
        }

        public CommandInput Retrieve()
        {
            return _inputBuilder.Build(_console.Read());
        }
    }
}