namespace SocialNetwork.Action.Command.Input
{
    public interface IInputBuilder
    {
        CommandInput Build(string input);
    }
}