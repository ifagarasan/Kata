namespace SocialNetwork.Infrastructure.Console
{
    public interface IConsole
    {
        string Read();
        void Write(string message);
    }
}
