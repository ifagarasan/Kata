namespace SocialNetwork.Model.Command.Input
{
    public interface IInputParser
    {
        CommandInput Parse(string input);
    }
}