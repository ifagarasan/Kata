namespace SocialNetwork.Command
{
    public interface ICommandDispatcher
    {
        ICommand Retrieve();
    }
}