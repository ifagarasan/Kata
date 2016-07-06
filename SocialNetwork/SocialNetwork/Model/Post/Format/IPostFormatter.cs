namespace SocialNetwork.Model.Post.Format
{
    public interface IPostFormatter
    {
        string FormatTimelinePost(PostRecord postRecord);
        string FormatWallPost(PostRecord postRecord);
    }
}