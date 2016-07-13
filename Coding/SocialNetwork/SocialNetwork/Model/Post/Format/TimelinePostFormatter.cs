namespace SocialNetwork.Model.Post.Format
{
    public class TimelinePostFormatter : IPostFormatter
    {
        private readonly IPostFormatter _postTimeFormatter;

        public TimelinePostFormatter(IPostFormatter postTimeFormatter)
        {
            _postTimeFormatter = postTimeFormatter;
        }

        public string Format(Post post) => $"{post.Message} {_postTimeFormatter.Format(post)}";
    }
}