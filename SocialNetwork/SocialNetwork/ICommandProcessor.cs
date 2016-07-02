namespace SocialNetwork
{
    public interface ICommandProcessor
    {
        void Process(ICommand command);
    }
}