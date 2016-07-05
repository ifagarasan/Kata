using System.Collections;
using System.Collections.Generic;

namespace SocialNetwork
{
    public interface ISocialEngine
    {
        void Post(string username, string message);
        IList<string> RetrieveTimeline(string username);
        IList<string> RetrieveWall(string username);
    }
}