using System.Collections.Generic;

namespace SocialNetwork.Model.Post
{
    public interface IPostRepository
    {
        void Insert(string username, string message);
        IList<Post> RetrieveTimeline(string username);
        IList<Post> RetrieveWall(User.User user);
    }
}