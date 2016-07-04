namespace SocialNetwork.Command
{
    public abstract class UserCommand: IUserCommand
    {
        protected UserCommand(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}