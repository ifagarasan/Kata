using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Input;

namespace SocialNetwork.Model.Social.Platform
{
    public class SocialPlatform: ISocialPlatform
    {
        private readonly IInputParser _inputParser;
        private readonly IConsole _console;
        private readonly ICommandFactory _commandFactory;

        public SocialPlatform(IInputParser inputParser, IConsole console, ICommandFactory commandFactory)
        {
            _inputParser = inputParser;
            _console = console;
            _commandFactory = commandFactory;
        }

        public void Run()
        {
            while (true)
            {
                var input = _inputParser.Parse(_console.Read());
                if (input.Type == InputType.Exit)
                    break;

                _commandFactory.Create(input).Execute();
            }
        }
    }
}