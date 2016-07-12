using System.Collections.Generic;

namespace SocialNetwork.Model.Post
{
    public interface IRepository
    {
        void Insert(User.User user, string message);
        IList<PostRecord> RetrieveTimeline(User.User user);
        IList<PostRecord> RetrieveWall(User.User user);
        void Follow(User.User user1, User.User user2);
    }
}