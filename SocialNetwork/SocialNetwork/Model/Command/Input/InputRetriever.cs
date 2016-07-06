using SocialNetwork.Infrastructure.Console;

namespace SocialNetwork.Model.Command.Input
{
    public class InputRetriever : IInputRetriever
    {
        private readonly IInputBuilder _inputBuilder;
        private readonly IConsole _console;

        public InputRetriever(IInputBuilder inputBuilder, IConsole console)
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