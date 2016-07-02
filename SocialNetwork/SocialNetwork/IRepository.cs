using System.Collections.Generic;

namespace SocialNetwork
{
    public interface IRepository
    {
        IList<string> Get(string username);

        void Insert(string username, string message);
    }
}