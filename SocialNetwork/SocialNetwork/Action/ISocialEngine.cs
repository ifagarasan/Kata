using System.Collections.Generic;

namespace SocialNetwork.Action
{
    public interface ISocialEngine
    {
        void Post(string username, string message);
        IList<string> RetrieveTimeline(string username);
        IList<string> RetrieveWall(string username);
        void Follow(string username, string followUsername);
    }
}