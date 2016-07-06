using System.Collections.Generic;

namespace SocialNetwork.Model
{
    public interface IRepository
    {
        void Insert(string username, string message);
        IList<Post> RetrieveTimeline(string username);
        IList<Post> RetrieveWall(string username);
        void Follow(string username, string followUsername);
    }
}