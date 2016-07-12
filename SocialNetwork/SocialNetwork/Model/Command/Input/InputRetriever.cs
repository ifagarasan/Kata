using SocialNetwork.Infrastructure.Console;

namespace SocialNetwork.Model.Command.Input
{
    public class InputRetriever : IInputRetriever
    {
        private readonly IInputParser _inputParser;
        private readonly IConsole _console;

        public InputRetriever(IInputParser inputParser, IConsole console)
        {
            _console = console;
            _inputParser = inputParser;
        }

        public CommandInput Retrieve()
        {
            return _inputParser.Parse(_console.Read());
        }
    }
}