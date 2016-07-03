using SocialNetwork.Command;

namespace SocialNetwork
{
    public interface ICommandTranslator
    {
        ICommand Translate(string command);
    }
}