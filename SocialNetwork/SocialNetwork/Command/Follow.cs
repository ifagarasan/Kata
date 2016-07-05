namespace SocialNetwork.Command
{
    public class Follow: UserCommand
    {
        public Follow(string username, string followUsername) : base(username)
        {
            FollowUsername = followUsername;
        }

        public string FollowUsername { get; set; }
    }
}