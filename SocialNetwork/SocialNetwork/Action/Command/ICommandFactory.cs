using SocialNetwork.Action.Command.Input;

namespace SocialNetwork.Action.Command
{
    public interface ICommandFactory
    {
        ICommand Create(CommandInput commandInput);
    }
}