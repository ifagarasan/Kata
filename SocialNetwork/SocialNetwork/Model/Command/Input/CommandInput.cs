namespace SocialNetwork.Model.Command.Input
{
    public class CommandInput
    {
        public CommandInput(CommandType type, string[] arguments)
        {
            Type = type;
            Arguments = arguments;
        }

        public string[] Arguments { get; }

        public CommandType Type { get; }
    }
}