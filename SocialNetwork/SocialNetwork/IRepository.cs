using System.Collections.Generic;

namespace SocialNetwork
{
    public interface IRepository
    {
        void Insert(string username, string message);
        IList<IPost> RetrieveTimeline(string username);
        IList<IPost> RetrieveWall(string username);
        void Follow(string username, string followUsername);
    }
}