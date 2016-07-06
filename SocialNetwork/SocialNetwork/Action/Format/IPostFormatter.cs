using SocialNetwork.Model;

namespace SocialNetwork.Action.Format
{
    public interface IPostFormatter
    {
        string FormatTimelinePost(Post post);
        string FormatWallPost(Post post);
    }
}