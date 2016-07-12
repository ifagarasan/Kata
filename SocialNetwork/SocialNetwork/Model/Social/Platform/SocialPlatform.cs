using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Input;

namespace SocialNetwork.Model.Social.Platform
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
                var input = _commandInputRetriever.Retrieve();
                if (input.Type == InputType.Exit)
                    break;

                _commandFactory.Create(input).Execute();
            }
        }
    }
}