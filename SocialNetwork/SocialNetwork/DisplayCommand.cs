namespace SocialNetwork
{
    public class DisplayCommand: ICommand
    {
        public DisplayCommand(string command)
        {
            Username = command;
        }

        public string Username { get; }
    }
}