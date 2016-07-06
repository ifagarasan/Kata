namespace SocialNetwork.Model.Command.Input
{
    public interface IInputBuilder
    {
        CommandInput Build(string input);
    }
}