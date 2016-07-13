namespace SocialNetwork.Model.Post.Format
{
    public class WallPostFormatter : IPostFormatter
    {
        private readonly IPostFormatter _postTimeFormatter;

        public WallPostFormatter(IPostFormatter postTimeFormatter)
        {
            _postTimeFormatter = postTimeFormatter;
        }

        public string Format(Post post) => $"{post.Username} - {post.Message} {_postTimeFormatter.Format(post)}";
    }
}