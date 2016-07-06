using System.Collections.Generic;

namespace SocialNetwork.Model.Post
{
    public interface IRepository
    {
        void Insert(string username, string message);
        IList<PostRecord> RetrieveTimeline(string username);
        IList<PostRecord> RetrieveWall(string username);
        void Follow(string username, string followUsername);
    }
}