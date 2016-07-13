using SocialNetwork.Model.Command.Input;

namespace SocialNetwork.Model.Command
{
    public interface ICommandFactory
    {
        ICommand Create(CommandInput commandInput);
    }
}