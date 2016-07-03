namespace SocialNetwork.Command.Processor
{
    public interface ICommandProcessorFactory
    {
        ICommandProcessor Create(ICommand command);
    }
}