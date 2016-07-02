using System.Collections;
using System.Collections.Generic;

namespace SocialNetwork
{
    public class Repository : IRepository
    {
        private readonly Dictionary<string, List<string>> _userMessages;

        public Repository()
        {
            _userMessages = new Dictionary<string, List<string>>();
        }

        public IList<string> Get(string username)
        {
            return _userMessages[username];
        }

        public void Insert(string username, string message)
        {
            if (!_userMessages.ContainsKey(username))
                _userMessages.Add(username, new List<string>());

            _userMessages[username].Add(message);
        }
    }
}