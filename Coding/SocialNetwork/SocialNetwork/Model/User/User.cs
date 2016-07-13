using System.Collections.Generic;

namespace SocialNetwork.Model.User
{
    public class User
    {
        private readonly List<string> _follows;

        public User(string username)
        {
            Username = username;

            _follows = new List<string>();
        }

        public string Username { get; }

        public IList<string> Follows => _follows.AsReadOnly();

        public void AddFollower(string followUsername) => _follows.Add(followUsername);
    }
}
