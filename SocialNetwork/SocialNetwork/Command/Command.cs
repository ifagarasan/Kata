namespace SocialNetwork.Command
{
    public abstract class Command: ICommand
    {
        protected Command(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}