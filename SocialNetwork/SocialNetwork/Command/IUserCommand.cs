namespace SocialNetwork.Command
{
    public interface IUserCommand: ICommand
    {
        string Username { get; }
    }
}