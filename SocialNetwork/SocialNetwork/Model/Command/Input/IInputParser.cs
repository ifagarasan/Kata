namespace SocialNetwork.Model.Command.Input
{
    public interface IInputParser
    {
        CommandInput Build(string input);
    }
}