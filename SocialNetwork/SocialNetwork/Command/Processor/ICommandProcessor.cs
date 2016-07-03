namespace SocialNetwork.Command.Processor
{
    public interface ICommandProcessor
    {
        void Process(ICommand command);
    }
}