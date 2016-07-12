namespace SocialNetwork.Model.Post.Format
{
    public interface IPostFormatter
    {
        string FormatTimelinePost(Post post);
        string FormatWallPost(Post post);
    }
}