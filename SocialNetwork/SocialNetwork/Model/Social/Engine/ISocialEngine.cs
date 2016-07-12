using System.Collections.Generic;

namespace SocialNetwork.Model.Social.Engine
{
    public interface ISocialEngine
    {
        void Post(User.User user, string message);
        IList<string> RetrieveTimeline(User.User user);
        IList<string> RetrieveWall(User.User user);
        void Follow(User.User user, User.User userToFollow);
    }
}