namespace SocialNetwork.Model.Command.Input
{
    public class CommandInput
    {
        public CommandInput(InputType type, string[] arguments)
        {
            Type = type;
            Arguments = arguments;
        }

        public string[] Arguments { get; }

        public InputType Type { get; }
    }
}