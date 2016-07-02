namespace SocialNetwork
{
    public class PostCommand: ICommand
    {
        public PostCommand(string username, string content)
        {
            Username = username;
            Content = content;
        }

        public string Username { get; }
        public string Content { get; }
    }
}