namespace SocialNetwork.Command
{
    public interface ICommandTranslator
    {
        ICommand Translate(string command);
    }
}