namespace SocialNetwork.Command.Processor
{
    public abstract class CommandProcessor : ICommandProcessor
    {
        protected CommandProcessor(ISocialEngine socialEngine, IConsole console)
        {
            SocialEngine = socialEngine;
            Console = console;
        }

        protected IConsole Console { get; private set; }
        protected ISocialEngine SocialEngine { get; private set; }

        public abstract void Process(ICommand command);
    }
}