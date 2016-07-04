namespace SocialNetwork.Command
{
    public class PostMessage: UserCommand
    {
        public PostMessage(string username, string message): base(username)
        {
            Message = message;
        }

        public string Message { get; }
    }
}