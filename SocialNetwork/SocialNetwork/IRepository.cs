using System.Collections.Generic;

namespace SocialNetwork
{
    public interface IRepository
    {
        void Insert(string username, string message);
        IList<IPost> RetrieveUserMessages(string username);
    }
}