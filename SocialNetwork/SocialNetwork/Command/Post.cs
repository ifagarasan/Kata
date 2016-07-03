namespace SocialNetwork.Command
{
    public class Post: Command
    {
        public Post(string username, string message): base(username)
        {
            Message = message;
        }

        public string Message { get; }
    }
}