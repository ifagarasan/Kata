using SocialNetwork.Command;

namespace SocialNetwork
{
    public interface ICommandDispatcher
    {
        ICommand Retrieve();
    }
}